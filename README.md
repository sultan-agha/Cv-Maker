<h1>CV Maker Web Application</h1>
    <p>
        This project is a web application built using ASP.NET Core with Razor Pages and utilizes a working database. The application allows users to create and manage their CVs online. Below you will find information on the project structure, functionality, and implementation details.
    </p>

    <h2>Project Structure</h2>
    <p>The project follows the ASP.NET Core conventions and has the following structure:</p>

    <ul>
        <li><strong>Models:</strong> Contains the data models used for storing CV information in the database.</li>
        <li><strong>ViewModels:</strong> Contains the view models used for data binding and validation in the Razor Pages.</li>
        <li><strong>Pages:</strong> Contains the Razor Pages that handle the user interface and logic.</li>
        <li><strong>Services:</strong> Contains one or more service classes responsible for business logic, including grade calculation and CRUD operations on the database.</li>
        <li><strong>Data:</strong> Contains the DbContext class and migration files for managing the database schema using Entity Framework Core.</li>
        <li><strong>wwwroot:</strong> Contains static files such as CSS stylesheets and client-side scripts.</li>
        <li><strong>Shared:</strong> Contains the shared layout (_Layout.cshtml) and other shared views.</li>
    </ul>

    <h2>Functionality</h2>

    <h3>Home Page</h3>
    <p>The home page displays a welcome message and may include a picture.</p>

    <h3>Send CV Page</h3>
    <p>The Send CV page allows users to fill out a form with the following information:</p>
    
    <ul>
        <li>First name</li>
        <li>Last name</li>
        <li>Date of Birth</li>
        <li>Nationality (select from a dropdown list)</li>
        <li>Gender (select using radio buttons)</li>
        <li>Programming Skills (select from a list of checkboxes)</li>
        <li>Email</li>
        <li>Confirm Email (validated to match the email)</li>
        <li>Verification Fields (X and Y numbers, and the sum of X and Y)</li>
        <li>Photo (upload a file)</li>
    </ul>

    <p>The form is validated both on the client-side and server-side. If the sum of X and Y is not equal to the provided sum, an error message is displayed. All validations are shown in a summary validation.</p>

    <p>If all validations pass, the user is redirected to the SummaryCV page, which displays the submitted information along with a calculated grade. The grade is determined based on the selected programming skills (10 points per skill) and the gender (additional 5 points for male, 10 points for female).</p>

    <p>The submitted information is saved in the database, except for the validation fields.</p>

    <h3>Browse CVs Page</h3>
    <p>The Browse CVs page lists all available CVs stored in the database in a table format. Each entry includes the full name, grade, and options to download the CV, edit the CV, or delete it.</p>

    <p>A button is provided on this page to download a Word or PDF file containing the CV information.</p>

    <h2>Implementation Details</h2>
    <p>The project utilizes Entity Framework Core (EF Core) for database operations, following the code-first approach.</p>

    <p>Tag Helpers are used for data annotation-based validations and to simplify rendering HTML elements in Razor Pages.</p>

    <p>Model binding is implemented to bind data from HTTP requests to view models and data models.</p>

    <p>Dependency injection is used to inject one or more service classes responsible for calculating grades and performing CRUD operations on the database.</p>

    <h2>Getting Started</h2>
    <p>To run the project locally, follow these steps:</p>

    <ol>
        <li>Clone the repository: &lt;repository_url&gt;</li>
        <li>Install the required dependencies and tools.</li>
        <li>Set up the database connection in the appsettings.json file.</li>
        <li>Apply the database migrations to create the required schema.</li>
        <li>Build and run the application.</li>
    </ol>

    <h2>Additional Notes</h2>
    <p>Make sure to customize the design of the pages to provide an attractive user interface. Consider adding authentication and authorization mechanisms to secure the application if required.</p>
