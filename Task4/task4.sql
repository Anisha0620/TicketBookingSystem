-- Task 4: Subquery and its types

DECLARE @venue_id INT = 1; -- Replace with the actual venue ID you want to use

-- 1. Calculate the Average Ticket Price for Events in Each Venue Using a Subquery
SELECT v.venue_name, 
       (SELECT AVG(ticket_price) 
        FROM Event e 
        WHERE e.venue_id = v.venue_id) AS average_ticket_price
FROM Venue v;

-- 2. Find Events with More Than 50% of Tickets Sold using a subquery
SELECT event_name
FROM Event e
WHERE (SELECT (total_seats - available_seats) * 100.0 / total_seats 
       FROM Event 
       WHERE event_id = e.event_id) > 50;

-- 3. Calculate the Total Number of Tickets Sold for Each Event
SELECT event_name, 
       (SELECT SUM(num_tickets) 
        FROM Booking 
        WHERE event_id = e.event_id) AS total_tickets_sold
FROM Event e;

-- 4. Find Users Who Have Not Booked Any Tickets Using a NOT EXISTS Subquery
SELECT customer_name
FROM Customer c
WHERE NOT EXISTS (SELECT 1 
                  FROM Booking b 
                  WHERE b.customer_id = c.customer_id);

-- 5. List Events with No Ticket Sales Using a NOT IN Subquery
SELECT event_name
FROM Event e
WHERE event_id NOT IN (SELECT event_id 
                       FROM Booking);

-- 6. Calculate the Total Number of Tickets Sold for Each Event Type Using a Subquery in the FROM Clause
SELECT event_type, 
       SUM(total_tickets) AS total_tickets
FROM (SELECT e.event_type, 
             SUM(b.num_tickets) AS total_tickets
      FROM Event e
      JOIN Booking b ON e.event_id = b.event_id
      GROUP BY e.event_type, e.event_id) AS ticket_summary
GROUP BY event_type;

-- 7. Find Events with Ticket Prices Higher Than the Average Ticket Price Using a Subquery in the WHERE Clause
SELECT event_name
FROM Event e
WHERE ticket_price > (SELECT AVG(ticket_price) FROM Event);

-- 8. Calculate the Total Revenue Generated by Events for Each User Using a Correlated Subquery
SELECT c.customer_name, 
       (SELECT SUM(b.total_cost) 
        FROM Booking b 
        WHERE b.customer_id = c.customer_id) AS total_revenue
FROM Customer c;

-- 9. List Users Who Have Booked Tickets for Events in a Given Venue Using a Subquery in the WHERE Clause
SELECT c.customer_name
FROM Customer c
WHERE c.customer_id IN (SELECT b.customer_id 
                        FROM Booking b 
                        JOIN Event e ON b.event_id = e.event_id 
                        WHERE e.venue_id = @venue_id);  -- Using the declared variable

-- 10. Calculate the Total Number of Tickets Sold for Each Event Category Using a Subquery with GROUP BY
SELECT e.event_type, 
       (SELECT SUM(b.num_tickets) 
        FROM Booking b 
        WHERE b.event_id IN (SELECT event_id 
                             FROM Event 
                             WHERE event_type = e.event_type)) AS total_tickets
FROM Event e
GROUP BY e.event_type;

-- 11. Find Users Who Have Booked Tickets for Events in each Month Using a Subquery with DATE_FORMAT
SELECT c.customer_name
FROM Customer c
WHERE c.customer_id IN (SELECT b.customer_id 
                        FROM Booking b 
                        JOIN Event e ON b.event_id = e.event_id 
                        WHERE MONTH(e.event_date) = MONTH(GETDATE()));  -- Current month

-- 12. Calculate the Average Ticket Price for Events in Each Venue Using a Subquery
SELECT v.venue_name, 
       (SELECT AVG(ticket_price) 
        FROM Event e 
        WHERE e.venue_id = v.venue_id) AS average_ticket_price
FROM Venue v;