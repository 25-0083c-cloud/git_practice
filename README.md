Project Overview
The MKCinema Ticket Booking System is a lightweight, interactive console application built in C# that simulates a self-service movie ticketing kiosk for MKCinema at Alabang Town Center.

The program provides a complete, step-by-step customer experience—from account creation to ticket printing. It manages user authentication, keeps track of movie and time schedules, displays a color-coded theater seating chart, handles pricing with discount rules, and generates a finalized digital receipt.

Core Features & Workflow
User Account Control: Users can register a temporary account on the spot or log in. The system includes security logic that permits an administrative bypass (admin / 1234) and locks out users after three failed login attempts.

Live Seating Chart: The system creates a 5x10 seating grid (Rows A to E). To make the simulation realistic, it randomly marks between 8 and 16 seats as already taken (X) before the user looks at the map.

Color-Coded Visuals: It uses terminal colors to help users scan the theater layout at a glance: Green means a seat is available, while Dark Yellow indicates it is occupied.

Strict Input Validation: The system ensures data integrity by preventing users from selecting non-existent movies or showtimes, picking already reserved seats, or typing invalid commands.

Pricing Engine: Tickets are priced at a flat rate of ₱300. The system checks if the customer qualifies for a 20% PWD (Persons with Disability) discount, calculates the subtotal, and updates the final price accordingly.

Receipt Layout: Upon booking confirmation, the system clears standard prompts to output a clean, formatted receipt containing the ticket count, selected seats, final transaction price, and a precise timestamp.

Technical Highlights
Data Structures: Uses multi-dimensional 2D arrays (string[,]) to map coordinates out of rows and columns, alongside single-dimensional arrays for schedules and movie titles.

Control Flow: Utilizes nested loops for map rendering and searching, conditional statements (if-else) for input filtering, and incremental trial counters for security.

Native Libraries: Leverages the System.Random class for procedural seat filling and System.DateTime for printing accurate transactional receipts.
