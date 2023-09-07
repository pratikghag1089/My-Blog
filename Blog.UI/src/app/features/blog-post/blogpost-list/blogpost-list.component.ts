import { Component, OnInit } from '@angular/core';
import { BlogPostService } from '../services/blogpost.services';
import { Observable } from 'rxjs';
import { Category } from '../../category/models/category.model';
import { BlogPost } from '../models/blogpost.model';
import { CategoryService } from '../../category/services/category.service';

@Component({
  selector: 'app-blogpost-list',
  templateUrl: './blogpost-list.component.html',
  styleUrls: ['./blogpost-list.component.css']
})
export class BlogpostListComponent implements OnInit {
  
  blogPosts$?: Observable<BlogPost[]>;

  constructor(private blogPostService: BlogPostService){

  }


  ngOnInit(): void {
    this.blogPosts$ = this.blogPostService.getAllBlogPosts();
  }
}
