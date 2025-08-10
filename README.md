Learning .NET and backend development with this project,
using ASP.NET Core and O
penAPI, EFCore,Windows Forms for front end, SSMS for the SQL server,
a bit of HTML CSS And JS for a password reset page, 
(BEST THING I ADDED WAS THE LIGH/DARK MODE, EVERY APP NEEDS ONE!)
i've created a Sign in/up pages, administrative/customer pages with the functionality of:

Admin: 
+ Adding Books to the library, removing one book out of the stack (so if there is 3 you can remove one and it'll be 2 in the entire library),
+ Removing the Book by Root (as in if there are 30 books, and we can't give them out anymore or something of the sort you get rid of all of them),
+ Editing the Book (so if we want to change an author or the name, or we had a mistake in the name we can, and it keeps the Id the same)
+ Seeing Who took out what book with a special conttorl tab for indevidual customers
+ being able to "Send the collection department" (Which basically retrives the book and forces Fines on the person who took out the book too long)
+ With in the Customer panel you can Force delete someones Account, but it won't let you close their account if they have checkouts so you HAVE to get the books back from them.

all tho the front end of the application doesn't look ravashing, it is quite functional and that's what i wanted to learn and do,
on the Customer page we have simple but effective ways to just do what the app is made to do, functionality:

Customer:
+ You can take the book out of the library, as in check it out Etc.
+ You can return the books you've taken out
+ And you can pay the overdue fine on it, you can not return a book that you need to pay a fine for without paying the fine.

ON THE BACK END SIDE OF THINGS!
(The fun parts)

Whenever adding ANYTHING (besides admins, they're just inserted in the database, idk how anyone would make an admin sign up ngl... inserting seemed the best way),
it sends to the api.
with that being said lets dive in.

when you sign up as a customer, the database gets your Name(probably should also get the last name), 
it also gets your gov id, a password and an email

Once you sign up the back end with a burner email sends you a "you have signed up" thing, never got around to the "click here to varrify" part
Then "as standard" i think you get kicked out in to the sign in page, and then you have to reenter your name and password
(also password is not hashed... i can figure out how but for testing it was going to be a shity)
the customer gets asgined a library card, and a CustomerId in the SQL Db

for books it's the same, it gets the name and author, author if it's new gets a new Id, if not you can scroll down and search the author or have it filled 
authors have Ids and same with books ofc, books has the list of authors atached so i can display it on the datagrid 

so as said everything has an obj and an id from admins to customers to books to authors, and everything is kept in the Db 

the selection happens by clicking the book you want which selects the entire row and then it can be taken out easy 
and you select the entire row so it's easier to not screw up

anyway
that's probably it for the read me.
