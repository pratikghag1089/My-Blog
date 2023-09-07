import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment.development';
import { AddBlogPostRequest } from '../models/add-blogpost.model';
import { BlogPost } from '../models/blogpost.model';
import { UpdateBlogPostRequest } from '../models/update-blogpost-request.model';

@Injectable({
  providedIn: 'root'
})
export class BlogPostService {

  constructor(private http: HttpClient) { }

  addBlogPost(model: AddBlogPostRequest): Observable<void> {
    return this.http.post<void>(`${environment.apiBaseUrl}/api/blogPosts`, model);
  }

  getAllBlogPosts(): Observable<BlogPost[]> {
    return this.http.get<BlogPost[]>(`${environment.apiBaseUrl}/api/blogPosts`);
  }

  getBlogPostById(id: string): Observable<BlogPost> {
    return this.http.get<BlogPost>(`${environment.apiBaseUrl}/api/blogPosts/${id}`);
  }

  editBlogPost(id?: string | null, model?: UpdateBlogPostRequest): Observable<BlogPost> {
    return this.http.put<BlogPost>(`${environment.apiBaseUrl}/api/blogPosts/${id}`, model);
  }

  deleteBlogPostById(id?: string | null): Observable<BlogPost> {
    return this.http.delete<BlogPost>(`${environment.apiBaseUrl}/api/blogPosts/${id}`);
  }
}
