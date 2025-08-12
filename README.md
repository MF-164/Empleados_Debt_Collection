# Empleados Debt Collection

## Project Overview

Empleados Debt Collection is a professional, real-world debt collection system developed for active contractors and business clients. The system manages the entire collection workflow end-to-end, from registering invoices and tracking payments to calculating commissions and generating detailed monthly reports.

Built with cutting-edge technologies including **ASP.NET Core (MVC & API)**, **Entity Framework Core (EF Core)**, and **AutoMapper**, the system is designed with a clean, modular layered architecture ensuring maintainability, scalability, and performance.

## Key Features

- **Client and Agent Management:** Hierarchical management of agents (intermediaries), clients, and their work sites.
- **Invoice and Payment Tracking:** Create, update, and monitor invoice statuses and actual payments, including partial and deferred payments.
- **Daily Work Reports:** Record daily work hours per site and client, differentiating between regular and professional employees with variable rates.
- **Automated Calculations:** VAT-inclusive invoice totals, payment differences, and commission calculations for agents.
- **Comprehensive Reporting:** Generate detailed reports by client, site, month, payment status, and agent commissions.
- **Approval Workflows:** Manage contractor approvals and invoice signature statuses.
- **Future-Ready:** Plans to add PDF/Excel export functionality and enhanced UI features.

## System Architecture

The system is built following a layered architecture pattern with clear separation of concerns:

- **Core Layer:** Implements business logic including debt management, payment processing, and commission calculations.
- **API Layer:** RESTful API built with ASP.NET Core to facilitate communication between frontend clients and backend services.
- **Data Layer:** Uses Entity Framework Core for efficient data access and management, encapsulating database operations.
- **Supporting Layers:** Repository pattern, service layer, controllers, and ViewModels for clean and testable code.

## Technologies Used

- **Backend:** ASP.NET Core MVC and Web API  
- **ORM:** Entity Framework Core  
- **Mapping:** AutoMapper  
- **API Design:** RESTful API  
- **Architecture:** Layered design (Repository, Service, Controller, ViewModel)  
- **Database:** SQL Serve

## Entities and Data Models

- **Agent:** Intermediary bringing clients to the company  
- **Client:** Contractor clients, each linked to an agent  
- **Site:** Work locations associated with clients  
- **DailyWorkReport:** Records of daily work hours by site and client  
- **InvoiceRecord:** Monthly invoice entries with detailed payment tracking

## Development Team and Context

This project is actively developed for a **real, existing client** within a professional environment. The development team consists of two developers working collaboratively on full end-to-end solutions, from business logic and API development to data integration and reporting functionalities.

## Getting Started

To contribute or deploy the system, clone the repository and set up the database context. The modular design supports easy extension and maintenance.

## Future Roadmap

- Export reports in PDF and Excel formats  
- Enhanced user interface for daily reports and invoice management  
- Automated notification system for payment reminders

---

For more details or to contribute, please contact the development team or visit the repository.

---

*This project demonstrates professional-grade development practices and real-world application delivery.*
