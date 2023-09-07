import { Component, OnDestroy, OnInit } from '@angular/core';
import { AddBlogPostRequest } from '../models/add-blogpost.model';
import { BlogPostService } from '../services/blogpost.services';
import { Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { CategoryService } from '../../category/services/category.service';
import { Category } from '../../category/models/category.model';

@Component({
  selector: 'app-add-blogpost',
  templateUrl: './add-blogpost.component.html',
  styleUrls: ['./add-blogpost.component.css']
})
export class AddBlogpostComponent implements OnDestroy, OnInit {
  model: AddBlogPostRequest;
  private addBlogPostSubscription?: Subscription;

  categories$?: Observable<Category[]>;


  constructor(private blogPostService: BlogPostService, private categoryService: CategoryService, private router: Router) {
    this.model = {
      title: '',
      shortDescription: '',
      content: '',
      featuredImageUrl:  '',
      urlHandle:  '',
      author:  '',
      publishedDate: new Date(),
      isVisible: true,
      categoryIds: []
    };   
  }

  ngOnInit(): void {
    this.categories$ = this.categoryService.getAllCategories();
  }

  onFormSubmit(){
    this.addBlogPostSubscription = this.blogPostService.addBlogPost(this.model).subscribe({
      next: (response) => {
        console.log('This was success!!!!');
        this.router.navigateByUrl('/admin/blogposts');
      },
      error: (error) => {

      } 
    });
  }

  ngOnDestroy(): void {
    this.addBlogPostSubscription?.unsubscribe();
  }
}
