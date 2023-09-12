import { Component, OnInit } from '@angular/core';
import { BlogPostService } from '../../blog-post/services/blogpost.services';
import { Observable } from 'rxjs';
import { BlogPost } from '../../blog-post/models/blogpost.model';

@Component({
  selector: 'app-blog-home',
  templateUrl: './blog-home.component.html',
  styleUrls: ['./blog-home.component.css']
})
export class BlogHomeComponent implements OnInit {
  
  blogs$? : Observable<BlogPost[]>;

  constructor(private blogPostService: BlogPostService) {
    
  }

  ngOnInit(): void {
    this.blogs$ = this.blogPostService.getAllBlogPosts();
  }

}
