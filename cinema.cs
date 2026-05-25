 // variables
        string username = "";
        string password = "";
        string isCustomer = "";
        string selectedMovie = "";
        string selectedTime = "";
        string isPWD = "";
        string confirm = "";
        string name = "";
        double discount = 0;
        double total = 0;
        int numSeats = 0;
        int movieChoice = 0;
        int timeChoice = 0;
        int ticketPrice = 300;

        string[] movies = { "Avengers: Endgame", "The Amazing Spider-Man", "Imagine Me and You" };
        string[] times = { "12:00 PM", "3:00 PM", "6:00 PM", "9:00 PM" };
        char[] rows = { 'A', 'B', 'C', 'D', 'E' };
        int seatsPerRow = 10;

        string registeredUsername = null;
        string registeredPassword = null;

This part sets up all the variables and lists the program will need, like movies, times, seats, and user information. It basically prepares everything before the program starts running.



 // pick category: register or login
        Console.Write("Do you want to Register or Login? (register/login): ");
        string category = Console.ReadLine().ToLower();

        if (category == "register")
        {
            Console.Write("Create a username: ");
            registeredUsername = Console.ReadLine();
            Console.Write("Create a password: ");
            registeredPassword = Console.ReadLine();

            Console.WriteLine("Registration successful. Please login now.");
            category = "login";
        }

        if (category == "login")
        {
            for (int attempts = 0; attempts < 3; attempts++)
            {
                Console.Write("Enter username: ");
                username = Console.ReadLine();
                Console.Write("Enter password: ");
                password = Console.ReadLine();

                if ((registeredUsername != null && username == registeredUsername && password == registeredPassword) || (username == "admin" && password == "1234"))
                {
                    Console.WriteLine("Login successful.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid login. Try again.");
                    if (attempts == 2)
                    {
                        Console.WriteLine("Too many failed attempts. Access denied.");
                        return;
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

This part lets the user either register (create an account) or login.
If they choose to register, they create a username and password, then are told to log in.
If they choose login, they must enter their username and password correctly.
The program gives them 3 chances to log in using a for loop — the loop repeats up to 3 times until they enter the correct info.
If they fail 3 times, the program stops.
If they type something other than "register" or "login", it shows “Invalid choice” and ends.
In short:
This section checks if the user has permission to continue by making sure they’re logged in correctly.



 // seats
        string[,] seats = new string[rows.Length, seatsPerRow];
        Random rand = new Random();

        for (int i = 0; i < rows.Length; i++)
        {
            for (int j = 0; j < seatsPerRow; j++)
            {
                seats[i, j] = $"{rows[i]}{j + 1}";
            }
        }

        int reservedCount = rand.Next(8, 16);
        for (int k = 0; k < reservedCount; k++)
        {
            int rowIndex = rand.Next(rows.Length);
            int seatIndex = rand.Next(seatsPerRow);
            if (seats[rowIndex, seatIndex] != "X")
            {
                seats[rowIndex, seatIndex] = "X"; // reserved
            }
        }

This part sets up the cinema seats.
string[,] seats creates a 2D array for rows and seats (like a grid).
The first nested for loop fills each seat with a label like "A1", "A2", etc.
Then it randomly marks some seats as reserved ("X") using Random.
The second for loop repeats the reservation process several times to block some seats before the user picks.
In short:
This section prepares the seat map and randomly reserves some seats so the user can only choose from the available ones.


Console.Write("Are you a customer? (yes/no): ");
        isCustomer = Console.ReadLine().ToLower();

        if (isCustomer != "yes")
        {
            Console.WriteLine("Sorry, this service is for customers only.");
            return;
        }

        Console.WriteLine("Available Movies:");
        for (int i = 0; i < movies.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {movies[i]}");
        }

        Console.Write("Choose a movie (1-3): ");
        movieChoice = Convert.ToInt32(Console.ReadLine());

        if (!(movieChoice >= 1 && movieChoice <= 3))
        {
            Console.WriteLine("Invalid movie selection.");
            return;
        }

        selectedMovie = movies[movieChoice - 1];

        Console.WriteLine("Available Time Slots:");
        for (int i = 0; i < times.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {times[i]}");
        }

        Console.Write("Choose a time slot (1-4): ");
        timeChoice = Convert.ToInt32(Console.ReadLine());

        if (!(timeChoice >= 1 && timeChoice <= 4))
        {
            Console.WriteLine("Invalid time slot selected.");
            return;
        }

        selectedTime = times[timeChoice - 1];

This section lets the user choose a movie and showtime.
First, it asks if they are a customer. If not, the program stops.
Then it shows a numbered list of movies using a for loop so the user can pick.
It reads the user’s choice and checks if it’s valid. If valid, it stores the selected movie.
The same process is repeated for time slots: shows a numbered list, lets the user pick, and stores the chosen time.
In short:
This part ensures the user selects a valid movie and time before continuing.




Console.WriteLine("Seat Map (X = Reserved; Green=Available:");
        for (int i = 0; i < rows.Length; i++)
        {
            Console.Write($"{rows[i]}: ");
            for (int j = 0; j < seatsPerRow; j++)
            {
                string seat = seats[i, j];
                if (seat == "X")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow; 
                    Console.Write("X ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(seat + " ");
                }
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        Console.Write("How many seats would you like to book? ");
        numSeats = Convert.ToInt32(Console.ReadLine());
        string[] chosenSeats = new string[numSeats];

        for (int i = 0; i < numSeats; i++)
        {
            Console.Write($"Enter seat {i + 1} (e.g., A5): ");
            string seatChoice = Console.ReadLine().ToUpper();

            bool found = false;
            for (int r = 0; r < rows.Length; r++)
            {
                for (int c = 0; c < seatsPerRow; c++)
                {
                    if (seats[r, c] == seatChoice)
                    {
                        seats[r, c] = "Y"; 
                        chosenSeats[i] = seatChoice;
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }

            if (!found)
            {
                Console.WriteLine("Seat unavailable or already reserved, try again.");
                i--;
            }
        }

This part lets the user see the seat map and pick seats.
The first nested for loop prints all rows and seats:
"X" (reserved) is shown in yellow
Available seats are shown in green
Then it asks how many seats the user wants and creates an array to store their choices.
The second nested loops let the user pick specific seats:
Outer loop = for each seat the user wants
Inner loops = search the 2D seat array to see if the seat is available
If available, mark it "Y" (chosen) and save it
If not available, the user is asked to choose again
In short:
This section shows which seats are free, lets the user pick the ones they want, and prevents picking reserved seats.



Console.Write("Are you a PWD? (yes/no): ");
        isPWD = Console.ReadLine().ToLower();

        if (isPWD == "yes")
        {
            discount = 0.20;
            Console.WriteLine("PWD discount applied (20%).");
        }

        // calculate total cost
        total = ticketPrice * numSeats;
        total -= total * discount;

        Console.Write("Confirm booking? (yes/no): ");
        confirm = Console.ReadLine().ToLower();

        if (confirm != "yes")
        {
            Console.WriteLine("Booking canceled.");
            return;
        }

        Console.Write("Enter name for booking: ");
        name = Console.ReadLine();

        
This part handles discounts, total cost, and booking confirmation.
It asks if the user is a PWD; if yes, a 20% discount is applied.
Then it calculates the total price: ticket price × number of seats, minus any discount.
The program asks the user to confirm the booking; if they say no, it cancels and stops.
Finally, it asks for the name to use on the booking/ticket.
In short:
This section calculates the price, applies discounts if eligible, and confirms the booking before printing the ticket.

Console.WriteLine("\n\n================= MKCINEMA TICKET =================");
        Console.WriteLine($"Movie: {selectedMovie}");
        Console.WriteLine($"Time: {selectedTime}");
        Console.WriteLine($"Name: {name}");
        Console.Write("Seats: ");
        for (int i = 0; i < numSeats; i++)
        {
            Console.Write(chosenSeats[i]);
            if (i < numSeats - 1)
                Console.Write(", ");
        }
        Console.WriteLine();
        Console.WriteLine($"Number of Tickets: {numSeats}");
        Console.WriteLine($"Ticket Price: ₱{ticketPrice}");
        Console.WriteLine($"Total Paid: ₱{total}");
        if (discount > 0)
        {
            Console.WriteLine($"Discount Applied: {(discount * 100)}% (PWD)");
        }
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("MKCinema - Alabang Town Center");
        Console.WriteLine($"Date Issued: {DateTime.Now}");

This part prints the cinema ticket for the user.
It shows the movie, time, and name of the person who booked.
The for loop prints all the chosen seats, separated by commas.
It also displays the number of tickets, ticket price, total paid, and discount if any.
Finally, it prints the cinema name and the current date and time using DateTime.Now.
In short:
This section creates a clear ticket with all the booking details for the user.


