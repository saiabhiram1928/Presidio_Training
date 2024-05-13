use pubs;

select * from stores;
select * from sales;
select * from publishers;
select * from pub_info;
select * from titleauthor;
select * from titles;
select * from authors;
select * from roysched;
select * from discounts;
select * from jobs;
select * from employee;

--1) Print the storeid and number of orders for the store
select stor_id , count(stor_id) as "Number of orders" 
from sales group by stor_id
--2) print the number of orders for every title
select  title_id,count(stor_id) as "Number of Orders" 
from sales group by title_id
--3) print the publisher name and book name
select p.pub_name, t.title
from publishers p join titles t on p.pub_id = t.pub_id
--4) Print the author full name for al the authors
select concat(au_fname, ' ', au_lname) as "Full Name" from authors
--6) Print the author name, title name
select concat(a.au_fname, ' ', a.au_lname) as "Full Name", t.title 
from titleauthor tau join titles t on tau.title_id = t.title_id 
join authors a on a.au_id = tau.au_id
-- 7) print the author name, title name and the publisher name
select concat(a.au_fname, ' ', a.au_lname) as "Full Name", title, p.pub_name
from titleauthor ta join titles t on ta.title_id = t.title_id 
join authors a on a.au_id = ta.au_id
join publishers p on p.pub_id = t.pub_id
--8) Print the average price of books pulished by every publicher
select p.pub_id, avg(t.price) 'Average Price'
from titles as t
join publishers as p
on t.pub_id = p.pub_id
group by p.pub_id
--9) print the books published by 'Marjorie'
select * from titles where pub_id = (select pub_id
from publishers
where pub_name='Marjorie')
---  10) Print the order numbers of books published by 'New Moon Books'
select p.pub_name 'Publisher Name',s.ord_num 'Order Number'
from publishers as p
join titles as t
on t.pub_id=p.pub_id
join sales as s
on t.title_id=s.title_id
where p.pub_name='New Moon Books'
-- 11) Print the number of orders for every publisher
select p.pub_name "publisher name", COUNT(s.ord_num) "order count"
from sales s
join titles t on s.title_id = t.title_id
join publishers p on t.pub_id = p.pub_id
group by p.pub_name;
--12) print the order number , book name, quantity, price and the total price for all orders
select s.ord_num, t.title "book name", s.qty, t.price, (s.qty * t.price) "total price"
from sales s JOIN titles t on s.title_id = t.title_id;
 --13) print he total order quantity fro every book
select t.title, sum(qty) as "Total Order Quantity"
from titles t inner join sales s on t.title_id = s.title_id
group by t.title;
--14)print the total ordervalue for every book
select t.title, sum(s.qty*t.price) as "Total Order Value"
from titles t inner join sales s on t.title_id = s.title_id
group by t.title;
--15) print the orders that are for the books published by the publisher for which 'Paolo' works for
select s.ord_num, s.title_id, t.title, p.pub_name
from sales s
join titles t on s.title_id = t.title_id
join publishers p on t.pub_id = p.pub_id
join employee e on p.pub_id = e.pub_id
where e.fname = 'Paolo';