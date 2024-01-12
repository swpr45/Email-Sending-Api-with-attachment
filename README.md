# Email Sending API

A lightweight ASP.NET Core API for sending emails with attachments. Easily integrate email functionality into your applications, supporting quick and flexible email delivery.

## Features

- Send emails with attachments.
- Simple integration.
- Configurable SMTP settings.

## Getting Started

1. **Clone the repository:**

    ```bash
    git clone https://github.com/swpr45/Email-Sending-Api-with-attachment.git
    cd Email-Sending-Api-with-attachment.git
    ```

2. **Configure email settings:**

    Open the `appsettings.json` file and update the following SMTP settings:

    ```json
    {
      "EmailSettings": {
        "Email": "your-email@example.com",
        "Password": "your-email-app-password",
        "Host": "smtp.example.com",
        "Port": 587,
        "DisplayName": "Your App"
      }
    }
    ```

3. **Run the API:**

    ```bash
    dotnet run
    ```

4. **Send your first email:**

    Use the API endpoint `POST /api/Mailapi` to send emails. 

## Usage

### Send Email

Endpoint: `POST /api/Mailapi`

#### Request

```json
{
  "toEmail": "recipient@example.com",
  "subject": "Hello, World!",
  "body": "This is the email body.",
  "attachment": (optional) // Attach a file
}
