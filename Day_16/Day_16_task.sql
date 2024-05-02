-----q1---------
select title from titles;
select * from titles;
-----q2-------
select title from titles where pub_id = 1389;
-----q3--------
select *from titles where price between 10 and 15;
-----q4--------
select * from titles where price is NULL;
-----q5--------
select title from titles where title like 'The%';
-----q6--------
select title from titles where title not like '%v%';
-----q7--------
select * from titles order by royalty;
-----q8--------
select * from titles order by pub_id desc, type, price desc;
-----q9--------
select  type , avg(price) as "Average Price" from titles group by type;
-----q10-------
select DISTINCT(type) from titles;
-----q11--------
select TOP 2 * from titles order by price desc;
-----q12--------
select * from titles where type = 'business' and price < 20 and advance > 7000;
-----q13--------
select pub_id, count(*) as "book_count" from titles where (price between 15 and 25) and (title like '%It%')
group by pub_id having count(*) > 2 order by count(*);
-----q14--------
select * from authors where state = 'CA';
-----q15--------
select state, count(*) as "Number_of_Authors" from authors group by state;

