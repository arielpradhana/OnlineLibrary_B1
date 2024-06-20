CREATE TABLE PENGGUNA (
  member_id INTEGER PRIMARY KEY,
  name VARCHAR(100) NOT NULL,
  nim VARCHAR(12) NOT NULL,
  fakultas VARCHAR(32) NOT NULL,
  prodi VARCHAR(64) NOT NULL,
  address VARCHAR(200) NOT NULL,
  phone VARCHAR(20) NOT NULL
);


CREATE TABLE BUKU (
  book_id INTEGER PRIMARY KEY,
  title VARCHAR(200) NOT NULL,
  author VARCHAR(100) NOT NULL,
  publisher VARCHAR(100) NOT NULL,
  year_published DATE NOT NULL
);

CREATE TABLE PEMINJAMAN (
  checkout_id INTEGER PRIMARY KEY,
  member_id INTEGER NOT NULL,
  book_id INTEGER NOT NULL,
  checkout_date DATE NOT NULL,
  due_date DATE NOT NULL,
  return_date DATE,
  FOREIGN KEY (member_id) REFERENCES PENGGUNA(member_id),
  FOREIGN KEY (book_id) REFERENCES BUKU(book_id)
);

CREATE TABLE KATEGORI (
  category_id INTEGER PRIMARY KEY,
  name VARCHAR(100) NOT NULL
);

CREATE TABLE KATEGORI_BUKU (
  book_id INTEGER NOT NULL,
  category_id INTEGER NOT NULL,
  PRIMARY KEY (book_id, category_id),
  FOREIGN KEY (book_id) REFERENCES BUKU(book_id),
  FOREIGN KEY (category_id) REFERENCES KATEGORI(category_id)
);

CREATE TABLE ADMIN (
  admin_id INTEGER PRIMARY KEY,
  name VARCHAR(100) NOT NULL,
  password VARCHAR(100) NOT NULL
);

CREATE TABLE DENDA (
  fine_id INTEGER PRIMARY KEY,
  checkout_id INTEGER NOT NULL,
  member_id INTEGER NOT NULL,
  amount DECIMAL(10,2) NOT NULL,
  description VARCHAR(200) NOT NULL,
  FOREIGN KEY (checkout_id) REFERENCES PEMINJAMAN(checkout_id),
  FOREIGN KEY (member_id) REFERENCES PENGGUNA(member_id)
);

INSERT INTO PENGGUNA (member_id, name, nim, fakultas, prodi, address, phone)
VALUES
('00001', 'John Doe', '232410102056', 'Ilmu Komputer', 'Teknologi Informasi','Jalan Sudirman 123', '08123456789'),
('00002', 'Jane Doe', '232410102034', 'Ilmu Komputer', 'Teknologi Informasi', 'Jalan Thamrin 456', '08198765432'),
('00003', 'Bob Smith', '232410102016', 'Ilmu Komputer', 'Teknologi Informasi', 'Jalan Jakarta 789', '08111122233'),
('00004', 'Alice Johnson', '232410102026', 'Ilmu Komputer', 'Teknologi Informasi', 'Jalan Bandung 901', '08133344455'),
('00005', 'Mike Brown', '232410102056', 'Ilmu Komputer', 'Teknologi Informasi', 'Jalan Surabaya 234', '08155566677'),
('00006', 'Emily Chen', '232410102012', 'Ilmu Komputer', 'Teknologi Informasi', 'Jalan Medan 567', '08177788899'),
('00007', 'David Lee', '232410102053', 'Ilmu Komputer', 'Teknologi Informasi', 'Jalan Palembang 890', '08199900011'),
('00008', 'Sarah Taylor', '232410102051', 'Ilmu Komputer', 'Teknologi Informasi', 'Jalan Makassar 345', '08122233344'),
('00009', 'Kevin White', '232410102059', 'Ilmu Komputer', 'Teknologi Informasi', 'Jalan Pontianak 678', '08144455566'),
('00010', 'Lisa Nguyen', '232410102050', 'Ilmu Komputer', 'Teknologi Informasi', 'Jalan Banjarmasin 901', '08166677788');


INSERT INTO BUKU (book_id, title, author, publisher, year_published)
VALUES
('00001', 'Harry Potter', 'J.K. Rowling', 'Scholastic', '2000-01-01'),
('00002', 'The Lord of the Rings', 'J.R.R. Tolkien', 'Allen & Unwin', '1954-01-01'),
('00003', 'To Kill a Mockingbird', 'Harper Lee', 'J.B. Lippincott & Co.', '1960-01-01'),
('00004', 'The Hunger Games', 'Suzanne Collins', 'Scholastic Press', '2008-01-01'),
('00005', 'Pride and Prejudice', 'Jane Austen', 'T. Egerton', '1813-01-01'),
('00006', 'The Catcher in the Rye', 'J.D. Salinger', 'Little, Brown and Company', '1951-01-01'),
('00007', 'The Great Gatsby', 'F. Scott Fitzgerald', 'Charles Scribner Sons', '1925-01-01'),
('00008', '1984', 'George Orwell', 'Secker and Warburg', '1949-01-01'),
('00009', 'The Picture of Dorian Gray', 'Oscar Wilde', 'Lippincott Monthly Magazine', '1890-01-01'),
('00010', 'Wuthering Heights', 'Emily BrontÃƒÂ«', 'Thomas Cautley Newby', '1847-01-01');


INSERT INTO PEMINJAMAN (checkout_id, member_id, book_id, checkout_date, due_date, return_date)
VALUES
('00001', '00001', '00001', '2022-01-01', '2022-01-15', '2022-01-10'),
('00002', '00002', '00002', '2022-02-01', '2022-02-15', '2022-02-12'),
('00003', '00003', '00003', '2022-03-01', '2022-03-15', '2022-03-10'),
('00004', '00004', '00004', '2022-04-01', '2022-04-15', '2022-04-12'),
('00005', '00005', '00005', '2022-05-01', '2022-05-15', '2022-05-10'),
('00006', '00006', '00006', '2022-06-01', '2022-06-15', '2022-06-12'),
('00007', '00007', '00007', '2022-07-01', '2022-07-15', '2022-07-10'),
('00008', '00008', '00008', '2022-08-01', '2022-08-15', '2022-08-12'),
('00009', '00009', '00009', '2022-09-01', '2022-09-15', '2022-09-10'),
('00010', '00010', '00010', '2022-10-01', '2022-10-15', '2022-10-12');


INSERT INTO KATEGORI (category_id, name)
VALUES
('00001', 'Fantasy'),
('00002', 'Adventure'),
('00003', 'Romance'),
('00004', 'Mystery'),
('00005', 'Science Fiction'),
('00006', 'Horror'),
('00007', 'Biography'),
('00008', 'History'),
('00009', 'Travel'),
('00010', 'Self-Help');


INSERT INTO KATEGORI_BUKU (book_id, category_id)
VALUES
('00001', '00001'),
('00002', '00002'),
('00003', '00003'),
('00004', '00004'),
('00005', '00005'),
('00006', '00006'),
('00007', '00007'),
('00008', '00008'),
('00009', '00009'),
('00010', '00010');

INSERT INTO ADMIN (admin_id, name, password)
VALUES
('00001', 'onlinelibrary', '123')

INSERT INTO DENDA (fine_id, checkout_id, member_id, amount, description)
VALUES
('00001', '00001', '00001', 5000.00, 'Late return fine'),
('00002', '00002', '00002', 3000.00, 'Damage fine'),
('00003', '00003', '00003', 2000.00, 'Lost book fine'),
('00004', '00004', '00004', 1000.00, 'Overdue fine'),
('00005', '00005', '00005', 4000.00, 'Late return fine'),
('00006', '00006', '00006', 6000.00, 'Damage fine'),
('00007', '00007', '00007', 7000.00, 'Lost book fine'),
('00008', '00008', '00008', 8000.00, 'Overdue fine'),
('00009', '00009', '00009', 9000.00, 'Late return fine'),
('00010', '00010', '00010', 10000.00, 'Damage fine');

select * FROM DENDA

