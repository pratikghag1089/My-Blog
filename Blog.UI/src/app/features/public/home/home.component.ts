import { Component, OnInit } from '@angular/core';
import { BlogPostService } from '../../blog-post/services/blogpost.services';
import { Observable } from 'rxjs';
import { BlogPost } from '../../blog-post/models/blogpost.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  
  blogs$? : Observable<BlogPost[]>;

  constructor(private blogPostService: BlogPostService) {
    
  }

  ngOnInit(): void {
    this.blogs$ = this.blogPostService.getAllBlogPosts();
  }

}
