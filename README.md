# My-Blog 📝

Welcome to **My-Blog**, a simple blogging webapp built with popular tech stack to provide a simple and secure blogging experience. This can be a good starter for someone who wants to learn angular + .net api implementation.

## 🚀 Tech Stack

- **Frontend**: Angular
- **Backend**: .NET Core API 7
- **ORM**: EF Core
- **Database**: SQL Server

## 🌟 Features

1. **Categories**: Organize your content seamlessly.
2. **Blog Posts**:
   - Link your posts to relevant categories.
   - **Image Gallery Management**: Select or upload images for your blog posts with ease.
   - **Markdown Support**: Preview and display content using markdown for a rich text experience.
3. **Authentication**:
   - Register & login using JWT tokens.
   - Integration with .NET Core Identity Framework.
4. **User Roles**:
   - **Reader**: Enjoy reading content from various writers.
   - **Writer**: Contribute by writing and managing your blog posts.
5. **Admin & Roles Seeding**: Default seeding for admin and roles to kickstart the platform.
6. **API Access Control**: Manage API access based on user roles.
7. **Token Management**:
   - Angular saves the token in cookies upon login.
   - Tokens are stored in local storage for further use.
8. **Auth Guard**: Secure your Angular pages with implemented auth guards.

## 🛠 Installation & Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/My-Blog.git

2. Navigate to the project directory and install the required packages:
   ```bash
   cd My-Blog
   npm install
   ```

3. Set up your SQL Server and update the connection string in the `.NET Core API` settings.

4. Run the migrations to set up the database:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. Start the backend server:
   ```bash
   dotnet run
   ```

6. Navigate to the Angular project directory and start the frontend server:
   ```bash
   cd angular-app
   ng serve
   ```

7. Visit `http://localhost:4200/` in your browser to access the application.

## 🤝 Contributing

Contributions, issues, and feature requests are welcome! Feel free to check the [issues page](#).

## 📄 License

This project is [MIT](#) licensed.

## 📧 Contact

Created by [@pratikghag1089](https://github.com/pratikghag1089) - Feel free to reach out!
