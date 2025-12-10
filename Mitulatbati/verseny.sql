create table versenyzok 
(
  sorszam int primary key,  -- a versenyző sorszáma
  nev varchar(30),       	-- a versenyző neve
  elso_leng int,   			-- az első lengetés eredménye
  masodik_leng int,   		-- a második lengetés eredménye
  harmadik_leng int,   		-- a harmadik lengetés eredménye
);

insert into versenyzok values
(1, 'Példa Versenyző', 8, 9, 7);