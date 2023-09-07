import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { BlogPost } from '../models/blogpost.model';
import { UpdateBlogPostRequest } from '../models/update-blogpost-request.model';
import { BlogPostService } from '../services/blogpost.services';
import { CategoryService } from '../../category/services/category.service';
import { Category } from '../../category/models/category.model';

@Component({
  selector: 'app-edit-blogpost',
  templateUrl: './edit-blogpost.component.html',
  styleUrls: ['./edit-blogpost.component.css']
})
export class EditBlogpostComponent  implements OnInit, OnDestroy {

  id: string | null = null;

  paramsSubscription?: Subscription;
  editBlogPostSubscription?: Subscription;
  deleteBlogPostSubscription?: Subscription;
  blogPost?: BlogPost;
  categories$?: Observable<Category[]>;
  selectedCategories? : string[];
  isImageSelectorVisible: boolean = false;

  constructor(private route: ActivatedRoute, private blogPostService: BlogPostService, private categoryService: CategoryService, private router: Router) {
  }
  
  ngOnInit(): void {
    this.paramsSubscription = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');
      
        if(this.id){
          this.blogPostService.getBlogPostById(this.id).subscribe({
            next: (response) => {
              this.blogPost = response;
              this.selectedCategories = response.categories.map(e => e.id);
            }
          })
        }
      }
    });

    this.categories$ = this.categoryService.getAllCategories();

  }

  onFormSubmit(){
    const updateBlogPostRequest: UpdateBlogPostRequest = {
      title: this.blogPost?.title,
      shortDescription: this.blogPost?.shortDescription,
      content: this.blogPost?.content,
      featuredImageUrl:  this.blogPost?.featuredImageUrl,
      urlHandle:  this.blogPost?.urlHandle,
      author:  this.blogPost?.author,
      publishedDate: this.blogPost?.publishedDate,
      isVisible: this.blogPost?.isVisible,
      categoryIds: this.selectedCategories
    }

    this.editBlogPostSubscription = this.blogPostService.editBlogPost(this.id, updateBlogPostRequest).subscribe({
      next: (response) => {
        this.blogPost = response;
        this.router.navigateByUrl('/admin/blogposts');
      }
    });
  }

  onDelete(){
    this.deleteBlogPostSubscription = this.blogPostService.deleteBlogPostById(this.id).subscribe({
      next: (response) => {
        this.blogPost = response;
        this.router.navigateByUrl('/admin/blogposts');
      }
    });
  }

  openImageSelector(): void{
    this.isImageSelectorVisible = true;
  }

  closeImageSelector(): void{
    this.isImageSelectorVisible = false;
  }

  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
    this.editBlogPostSubscription?.unsubscribe();
  }
}
