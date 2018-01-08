# ReviewYourFavourites Project Assignment 
for the C# MVC Frameworks Course @ SoftUni

<h2>General Requirements</h2>
<ul>
<li>The application is implemented using <strong>NET Core</strong> framework.</li>
<li>It uses <strong>Razor</strong> template engine for generating the UI, together with <strong>partial views</strong>.</li>
<li><strong>Microsoft SQL Server</strong> as database back-end.</li>
<li>Use <strong>Entity Framework Core</strong> to access your database.</li>
<li><strong>MVC Areas</strong> to separate different parts of your application (ReviewArea, AdminArea).</li>
<li>The <strong>UI</strong> is responsive using <strong>Bootstrap</strong>.</li>
<li>It uses the standard <strong>NET Identity System</strong> for managing <strong>users</strong> and <strong>roles</strong>.
<ul>
<li>The user roles are: <strong>user</strong> and <strong>administrator, ProUser</strong>.</li>
</ul>
</li>
<li><strong>Error handling</strong> and <strong>data validation</strong> to avoid crashes when invalid data is entered (both <strong>client-side</strong> and <strong>server-side</strong>).</li>
<li>Handle correctly the special <strong>HTML characters</strong> and tags like <strong>&lt;br /&gt;</strong> and <strong>&lt;script&gt; (escape special characters).</strong></li>
<li><strong>Use </strong><strong>Dependency Injection.</strong></li>
<li><strong>Use </strong><strong>AutoМapping</strong><strong>.</strong></li>
<li><strong>Prevent from security vulnerabilities like SQL Injection, XSS, CSRF, parameter tampering, etc.</strong></li>
</ul>
<h2>Additional Requirements</h2>
<ul>
<li>Follow the best practices for Object Oriented design and <strong>high-quality code</strong> for the Web application:</li>
<ul>
<li>Use data encapsulation.</li>
<li>Use exception handling properly.</li>
<li>Use inheritance, abstraction and polymorphism properly.</li>
<li>Follow the principles of strong cohesion and loose coupling.</li>
<li>Correctly format and structure your code, name your identifiers and make the code readable.</li>
</ul>
<li>Well looking user interface (UI) somewhat.</li>
<li>Good usability (easy to use UI), thanks to partial views.</li>
<li>Supporting of all modern Web browsers.</li>
<li>Use caching where appropriate.</li>
<li>Use a <strong>source control system</strong> by &nbsp;- <strong>GitHub</strong>.</li>
</ul>
<h2>Business Logic</h2>
<ul>
<li>Guest Users
<ul>
<li>Can log in</li>
<li>Can Register</li>
<li>View Home page for <strong>Guest</strong> users</li>
</ul>
</li>
<li>Users (logged in)
<ul>
<li>View Home page for <strong>Authorized</strong> users</li>
<li>Can write comic review /review/comics/create</li>
<li>Can EDIT <strong>theirs posts. </strong>/review/comics/edit/{id}</li>
<li>Can DELETE <strong>their posts</strong> /review/comics/delete/{id}</li>
<li>Can view <strong>all </strong>published comic reviews /review/comics</li>
<li>Can view details (full info page) for any comic review/comics/details/{id}</li>
<li>Can see and edit their profile. E.g. Change avatar users/myprofile/{id}</li>
</ul>
</li>
<li>ProUsers
<ul>
<li>Have a special pro user badge in the menu</li>
<li>Have special pro user badge in their profile</li>
</ul>
</li>
<li>Administrators
<ul>
<li>Can EDIT DELETE comic reviews of <strong>ANY</strong> user</li>
<li>Have admin panel (TODO)</li>
</ul>
</li>
</ul>
<p>&nbsp;</p>
<h2>Seeded data - Test yourself</h2>
<ul>
	<li><strong>Normal</strong>, pass: Normal2017</li>
	<li><strong>ProUser</strong>, pass: ProUser2017</li>
	<li><strong>Administrator</strong>, pass: Administrator2017</li>
	<li>There are already comic reviews seeded.</li>
</ul>