import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryListComponent } from './features/category/category-list/category-list.component';
import { AddCategoryComponent } from './features/category/add-category/add-category.component';
import { EditCategoryComponent } from './features/category/edit-category/edit-category.component';
import { BlogpostListComponent } from './features/blog-post/blogpost-list/blogpost-list.component';
import { AddBlogpostComponent } from './features/blog-post/add-blogpost/add-blogpost.component';
import { EditBlogpostComponent } from './features/blog-post/edit-blogpost/edit-blogpost.component';
import { HomeComponent } from './features/public/home/home.component';
import { BlogDetailsComponent } from './features/public/blog-details/blog-details.component';
import { LoginComponent } from './features/auth/login/login.component';
import { authGuard } from './features/auth/guards/auth.guard';
import { BlogHomeComponent } from './features/public/blog-home/blog-home.component';
import { AboutMeComponent } from './features/public/about-me/about-me.component';
import { WorksComponent } from './features/public/works/works.component';

const routes: Routes = [
  {
    path: '', component: HomeComponent
  },
  {
    path: 'blogs', component: BlogHomeComponent
  },
  {
    path: 'about-me', component: AboutMeComponent
  },
  {
    path: 'works', component: WorksComponent
  },
  {
    path: 'login', component: LoginComponent
  },
  {
    path: 'blog/:url', component: BlogDetailsComponent
  },
  {
    path: 'admin/categories', component: CategoryListComponent, canActivate: [authGuard]
  },
  {
    path: 'admin/categories/add', component: AddCategoryComponent, canActivate: [authGuard]
  },
  {
    path: 'admin/categories/:id', component: EditCategoryComponent, canActivate: [authGuard]
  },
  {
    path: 'admin/blogposts', component: BlogpostListComponent, canActivate: [authGuard]
  },
  {
    path: 'admin/blogposts/add', component: AddBlogpostComponent, canActivate: [authGuard]
  },
  {
    path: 'admin/blogposts/:id', component: EditBlogpostComponent, canActivate: [authGuard]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {scrollPositionRestoration: 'enabled'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
