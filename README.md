# HangRabbit

This repository demonstrates a simple integration using **message-based communication with RabbitMQ** and **background processing with Hangfire**, developed with **.NET 9**.

---

## 📁 Project Structure

The solution is organized into three projects:

- **HangRabbit.Publisher**: A minimal API with a single POST endpoint that publishes messages to a RabbitMQ queue.
- **HangRabbit.HangFire**: Responsible for:
  - **Consuming messages** from the RabbitMQ queue.
  - **Executing scheduled background jobs** with Hangfire.
- **HangRabbit.Shared**: Contains shared models and configurations used across the two main projects.

---

## 🧠 How It Works

1. The **Publisher** sends a message to RabbitMQ via a POST endpoint.
2. The **HangFire** project:
   - Listens to the RabbitMQ queue and processes the messages.
   - Runs background jobs on a scheduled basis using Hangfire.

---

## 🛠️ Requirements

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download)
- RabbitMQ installed locally as a Windows service
- PostgreSQL (or another compatible database) used by Hangfire for job persistence

---

## 🐇 Setting Up RabbitMQ (Windows Service)

RabbitMQ was installed locally without Docker. To replicate this setup:

1. [Download and install Erlang](https://www.erlang.org/downloads)
2. [Download and install RabbitMQ](https://www.rabbitmq.com/download.html)
3. After installation, run the following commands in PowerShell or Command Prompt to enable and start the management plugin:

```bash
rabbitmq-plugins enable rabbitmq_management
rabbitmq-service start
```

- Management UI: http://localhost:15672

- Default credentials:
  
Username: guest

Password: guest

Make sure your appsettings.json or environment variables match this configuration.


---

## 🧱 Setting Up PostgreSQL for Hangfire

Hangfire uses PostgreSQL to store background job data. To configure:

1. Install PostgreSQL from https://www.postgresql.org/download/
2. Create a new database, for example: HangRabbit
3. Update your connection string in HangRabbit.HangFire/appsettings.Development.json:
   
```bash
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=HangRabbit;User Id=postgres;Password=yourpassword;"
}
```

---

## 🚀 Running the Solution
1. Ensure RabbitMQ and PostgreSQL are running locally.
2. Start the HangRabbit.HangFire project — it will:
   - Connect to RabbitMQ and PostgreSQL
   - Start listening to the queue
   - Run scheduled background jobs
3. Start the HangRabbit.Publisher project and call the POST endpoint /test to enqueue a message.

You can test it with a simple curl command:


---


🧪 Technologies Used
- .NET 9
- RabbitMQ (manual setup on Windows)
- Hangfire
- PostgreSQL
- Minimal APIs


