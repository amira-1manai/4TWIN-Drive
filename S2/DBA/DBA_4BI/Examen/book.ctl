LOAD DATA
   INFILE 'book.dat'
   APPEND INTO TABLE book
   Fields terminated by ','
   Optionally enclosed by '"'
   (
   book_title ,
   book_price "round(:book_price)",
   book_pages 
   )
