# EventEase

**EventEase** is a dynamic event management platform built using **ASP.NET Core MVC**. It allows users to create, manage, and participate in both public and private events. The application supports guest access for viewing public events and provides registered users with enhanced functionalities such as creating events, managing invitations, and categorizing events into past and upcoming sections.

## Project Purpose

The **EventEase** is designed to streamline the process of event creation and management. Whether you’re planning a private gathering or a public meetup, this platform simplifies inviting attendees, tracking participation, and keeping a record of events. By categorizing events into past and upcoming, users can maintain a clean and organized view of their schedules and social plans. This project offers a user-friendly interface for guests, event organizers, and invitees, ensuring seamless interaction and participation in both public and private events.

## Key Features

- **Public & Private Events**: Users can create events that are visible to everyone (public) or restricted to invited guests (private).
- **Guest User Access**: Guest users can browse and view only public events, while private events remain hidden.
- **Logged-in User Functionality**: 
    - View public events.
    - Access a personalized "My Events" section, showcasing events created by the user.
    - View events they have been invited to in the "Invited Events" section.
- **Event Invitations**: Users can invite others to private events using their email addresses.
- **Upcoming and Past Events**: Events are divided into upcoming and past sections, making it easier for users to track future and completed events.
- **Event Management**: Users can:
  - **Update Events**: Modify details of both public and private events.
  - **Delete Events**: Remove upcoming events. For past events, users are allowed only to delete them.
- **Secure Access**: Role-based access control ensures that only authorized users can create and manage events.

## Tech Stack

- **Backend & Frontend**: ASP.NET Core MVC (with Razor views)
- **Database**: LocalDB (MSSQLLocalDB)
- **ORM**: Entity Framework Core
- **Authentication**: ASP.NET Core Identity
- **Version Control**: Git

## Instructions for Running

### Prerequisites

Ensure that you have the following installed before setting up the project:

- [ASP .Net MVC 5](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/getting-started)
- [Entity Framework](https://learn.microsoft.com/en-us/ef/)

### Installation

1. **Clone the Repository**  
   Clone this repository to your local machine using the command:
   ```bash
   git clone https://github.com/theinfiniteprins/EventEase.git
   ```

2. **Set up Database**  
   Configure your SQL Server (if you are using SQL Database) and update the connection string in the ```Startup.cs```:
   ```bash
        public void ConfigureDatabases(IServiceCollection services)
        {
            services.AddDbContext<EventContext>(
                options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Database=EventEase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
            );
        }
    ```

    Then, apply migrations to set up the database using Entity Framework:
    1. Go to ```Tools > NuGet Package Manager > Package Manager Console``` and run below 2 Commands.
        ```
        PM> add-migration migrationName
        PM> update-database
        ```

2. **Access the Application** 
    Once running, access the application by navigating to:
    ```
    http://localhost:your-port-number/
    ```
    
### Screenshots

Login | Sign Up
------------ | -------------
<img src="./README Images/Login.png"/> | <img src="./README Images/Signup.png"/> 

Stranger Home | Logged in Home
------------- | ---------------
<img src="./README Images/StrangerHome.png"/> | <img src="./README Images/UserHome.png"/> 

My Events |
------------ |
<img src="./README Images/MyEvents.png"/> |

Invited Events |
------------ |
<img src="./README Images/InvitedEvents.png"/> |

Create Event |
------------ |
<img src="./README Images/CreateEvent.png"/> |

View Event |
------------ |
<img src="./README Images/ViewEvent.png"/> |