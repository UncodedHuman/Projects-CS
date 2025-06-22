DELETE FROM Students;
INSERT OR REPLACE INTO Students (LastName, Year, FirstName, StudentNumber, CreatedBy, CreatedDateTime, ModifiedBy, ModifiedDateTime, Class) 
 VALUES
    ('Boruc', 12, 'Alex Gabriel', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Nowicka', 12, 'Alicja Marta', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Trusi', 12, 'Antonina Aleksandra', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Korshun', 12, 'Egor', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Balta', 12, 'Elif Nisa', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Guluzade', 12, 'Emil', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Oh', 12, 'Hyunjoo', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Gandhi', 12, 'Kuba Arman', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Glowacki', 12, 'Latifa', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Barszczews', 12, 'Laura Barbara', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Kowalski', 12, 'Lubosz Roch', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Mielesz', 12, 'Maksymilian Jerzy', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Balta', 12, 'Mehmet Burak', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Kamecka', 12, 'Roza', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Ganiev', 12, 'Safa', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Wojciechow', 12, 'Samuel Adam', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Soyturk', 12, 'Sila', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Muzyka', 12, 'Sofija', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Stepien', 12, 'Szymon Piotr', '0000001',  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),   --Special case
    ('Olejarz', 12, 'Witold Stanisław', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Zhang', 12, 'Yi Qing', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Wu', 12, 'Zimo', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA'),
    ('Williams', 12, 'Zofia Maryla', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelA');

 
 INSERT OR REPLACE INTO Students (LastName, Year, FirstName, StudentNumber, CreatedBy, CreatedDateTime, ModifiedBy, ModifiedDateTime,  Class) 
 VALUES
    ('Cakar', 12, 'Ali Ihsan', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),
    ('Moiseenko', 12, 'Anastasia', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),
    ('Le', 12, 'Anh Thu', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),
    ('Jaskowiak', 12, 'Antoni', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),
    ('Khubchandani', 12, 'Aryan', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),
    ('Krylova', 12, 'Bozhena', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),
    ('Tabur', 12, 'Efe', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),
    ('Koç', 12, 'Fatima Mürşide', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),
    ('Tatar', 12, 'Huma', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),
    ('Góra', 12, 'Izabella Lilija', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),
    ('Kaur', 12, 'Jasleen Kaur', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),
    ('Warzęci', 12, 'Maciej Goberdhan', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),
    ('Stabinski', 12, 'Michal Czeslaw', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),
    ('Takahashi', 12, 'Mihi', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),
    ('Igamberdieva', 12, 'Sabina', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),
    ('Nguyen', 12, 'Son Thanh', '0069420',  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),   --Special case
    ('Vestor', 12, 'Tymur Romanovich', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),
    ('Svishchova', 12, 'Valeriya', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),
    ('Zakharov', 12, 'Vasilii', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),
    ('Xi', 12, 'Wu Chen', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB'),
    ('Okdem', 12, 'Zeynep', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'AS_LevelB');


 INSERT OR REPLACE INTO Students (LastName, Year, FirstName, StudentNumber, CreatedBy, CreatedDateTime, ModifiedBy, ModifiedDateTime,  Class) 
 VALUES
    ('Turkova', 12, 'Alina', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1A'),
    ('Huryanau', 12, 'Andrei', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1A'),
    ('Agasa', 12, 'Aniella Munyangabe', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1A'),
    ('Didenko', 12, 'Anna', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1A'),
    ('Huan', 12, 'Chongyu', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1A'),
    ('Gadet', 12, 'Giselle', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1A'),
    ('Kmiecinski', 12, 'Ignacy', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1A'),
    ('Dowżyk', 12, 'Igor Adam', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1A'),
    ('Hapeyeu', 12, 'Ilya', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1A'),
    ('Piec', 12, 'Jan Franciszek', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1A'),
    ('Szubartowski', 12, 'Jeremi Jan', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1A'),
    ('Moiseiev', 12, 'Kyrylo', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1A'),
    ('Dang', 12, 'Long Bao', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1A'),
    ('Kupfer', 12, 'Maksymilian', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1A'),
    ('Holynska', 12, 'Malgorzata Maria', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1A'),
    ('Siekanski', 12, 'Oliwier', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1A'),
    ('Stelmach', 12, 'Sophia Grace', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1A'),
    ('Alshahran', 12, 'Wasan Abdullah', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1A');


 INSERT OR REPLACE INTO Students (LastName, Year, FirstName, StudentNumber, CreatedBy, CreatedDateTime, ModifiedBy, ModifiedDateTime,  Class) 
 VALUES
    ('Firat', 12, 'Adil Esat', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1B'),
    ('Acik', 12, 'Ahmet Melih', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1B'),
    ('Ba', 12, 'Anastasia Yevgenievna', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1B'),
    ('Bury', 12, 'Antoni Franciszek', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1B'),
    ('Al-Sadi', 12, 'Hussein Ahmed', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1B'),
    ('Wolniak', 12, 'Jan Jarosław', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1B'),
    ('Michalski', 12, 'Kacper Dominik', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1B'),
    ('Adamenko', 12, 'Lev', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1B'),
    ('Milto', 12, 'Lizaveta', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1B'),
    ('Mozol', 12, 'Marcelina', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1B'),
    ('Beliankova', 12, 'Marharyta', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1B'),
    ('Radzieciak', 12, 'Maria', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1B'),
    ('Kovalenko', 12, 'Mykola', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1B'),
    ('Novosolova', 12, 'Sofia', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1B'),
    ('Ploumpis', 12, 'Sotirios', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1B'),
    ('Ding', 12, 'Xiang', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_1B');


 INSERT OR REPLACE INTO Students (LastName, Year, FirstName, StudentNumber, CreatedBy, CreatedDateTime, ModifiedBy, ModifiedDateTime,  Class) 
 VALUES
    ('Christy', 11, 'Alvin Abhishek', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A1'),
    ('Kyr', 11, 'Andrii Oleksandrovych', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A1'),
    ('Arzumanov', 11, 'Bronislav', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A1'),
    ('Nechai', 11, 'Daniil', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A1'),
    ('Kamarova', 11, 'Darya', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A1'),
    ('Pospiech', 11, 'Dominik', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A1'),
    ('Abdyjapbarova', 11, 'Fatma', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A1'),
    ('Domžalski', 11, 'Jakub', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A1'),
    ('Motwani', 11, 'Karina', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A1'),
    ('Mcmillan', 11, 'Maria Victoria', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A1'),
    ('Al-Sabahi', 11, 'Nsreen', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A1'),
    ('Miller', 11, 'Olaf Leon', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A1'),
    ('Jamtani', 11, 'Raahi Prakash', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A1'),
    ('Elgin', 11, 'Saadet', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A1'),
    ('Kaźmierczak', 11, 'Szymon', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A1'),
    ('Firat', 11, 'Yakup', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A1');


 INSERT OR REPLACE INTO Students (LastName, Year, FirstName, StudentNumber, CreatedBy, CreatedDateTime, ModifiedBy, ModifiedDateTime,  Class) 
 VALUES
    ('Szmyd', 11, 'Aleksander Jan', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A2'),
    ('Czutro', 11, 'Amelia Aleksandra', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A2'),
    ('Zielińska', 11, 'Aniela', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A2'),
    ('Yildiz', 11, 'Eymen', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A2'),
    ('Elhoreigy', 11, 'Jana Mohammed', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A2'),
    ('Deng', 11, 'Kevin', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A2'),
    ('Bahadir', 11, 'Kubra Tunay', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A2'),
    ('Kunicka', 11, 'Natalia Barbara', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A2'),
    ('Jachvliani', 11, 'Nita', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A2'),
    ('Erkol', 11, 'Nurbanu Zeyneb', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A2'),
    ('Solovich', 11, 'Timur', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A2'),
    ('Shramko', 11, 'Valerii', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A2'),
    ('Peng', 11, 'Yan-Lin', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A2'),
    ('Shuhaieva', 11, 'Yelyzaveta', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A2'),
    ('Qu', 11, 'Yicheng', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A2'),
    ('Eren', 11, 'Yusuf Emir', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A2'),
    ('Radzieciak', 11, 'Zofia', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11A2');

 
 INSERT OR REPLACE INTO Students (LastName, Year, FirstName, StudentNumber, CreatedBy, CreatedDateTime, ModifiedBy, ModifiedDateTime,  Class) 
 VALUES
    ('Kaptan', 11, 'Ahmet Hasan', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B1'),
    ('Musalnikov', 11, 'Aleksandr', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B1'),
    ('Sokołowska', 11, 'Amelia Antonina', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B1'),
    ('Kozłow', 11, 'Anna', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B1'),
    ('Shelestovich', 11, 'Artiom', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B1'),
    ('Korczak', 11, 'Dominika Anna', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B1'),
    ('Tanrikulu', 11, 'Erva Zehra', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B1'),
    ('Senatov', 11, 'Gleb', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B1'),
    ('Wisniewska', 11, 'Julia', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B1'),
    ('Chu', 11, 'Lanrui', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B1'),
    ('Limitowski', 11, 'Maksim', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B1'),
    ('Khurana', 11, 'Nina', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B1'),
    ('Syerik', 11, 'Nurbanu', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B1'),
    ('Soares', 11, 'Rafaela Wassolua', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B1'),
    ('Vatsenko', 11, 'Tymur', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B1'),
    ('Algaldo', 11, 'Yara Muqda Ayoob', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B1'),
    ('Ye', 11, 'Yongxin', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B1'),
    ('Kowalska', 11, 'Zofia', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B1'),
    ('Farkas', 11, 'Zora', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B1');


 INSERT OR REPLACE INTO Students (LastName, Year, FirstName, StudentNumber, CreatedBy, CreatedDateTime, ModifiedBy, ModifiedDateTime,  Class) 
 VALUES
    ('Pharasi', 11, 'Anushka', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2'),
    ('Volynets', 11, 'Arkadii', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2'),
    ('Borys', 11, 'Bianka', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2'),
    ('Chang', 11, 'Chen-Jui', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2'),
    ('Strutynskyi', 11, 'Danylo', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2'),
    ('Ammu', 11, 'Disha Karthic', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2'),
    ('Horbenko', 11, 'Daria', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2'),
    ('Maciejewska', 11, 'Elena', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2'),
    ('Jankyei', 11, 'Hakan', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2'),
    ('Karakus', 11, 'Kamila Nahide', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2'),
    ('Ploumpis', 11, 'Marios', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2'),
    ('Erdogan', 11, 'Ramazan', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2'),
    ('Khubchandani', 11, 'Samir', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2'),
    ('Chae', 11, 'Seoyeon', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2'),
    ('Singh', 11, 'Shirin', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2'),
    ('Lirnyk', 11, 'Sofiia', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2'),
    ('Vasylenko', 11, 'Taisiia', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2'),
    ('Pietrzak', 11, 'Viktoria Maria', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2'),
    ('Hryzodub', 11, 'Yelyzaveta', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2'),
    ('Shen', 11, 'Yuling', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year11B2');

 INSERT OR REPLACE INTO Students (LastName, Year, FirstName, StudentNumber, CreatedBy, CreatedDateTime, ModifiedBy, ModifiedDateTime,  Class) 
 VALUES
    ('Matkulov', 10, 'Alimzhan', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A'),
    ('Cafiero', 10, 'Aurora', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A'),
    ('Gunduz', 10, 'Azra Zehra', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A'),
    ('Tas', 10, 'Celil', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A'),
    ('Fomin', 10, 'Danyil', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A'),
    ('Wiśnik', 10, 'Dawid Robert', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A'),
    ('Danylovska', 10, 'Dolores', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A'),
    ('Davi', 10, 'Helena Cloe', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A'),
    ('Kalaiselvi', 10, 'Kabilan Kannan', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A'),
    ('Zhang', 10, 'Karol Jiale', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A'),
    ('Martin', 10, 'Lola Jeanpaul', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A'),
    ('Wazir', 10, 'Muhammad Bilal', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A'),
    ('Kumar', 10, 'Naitik', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A'),
    ('Serenli', 10, 'Nilgun', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A'),
    ('Budhkar', 10, 'Parth', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A'),
    ('Ersoy', 10, 'Seher', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A'),
    ('Riazi', 10, 'Seyed Elyas', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A'),
    ('Kuhanchyk', 10, 'Sofya', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A'),
    ('Gantulga', 10, 'Taivan-Amgalan', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A'),
    ('Pavlov', 10, 'Vladyslav', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10A');


 INSERT OR REPLACE INTO Students (LastName, Year, FirstName, StudentNumber, CreatedBy, CreatedDateTime, ModifiedBy, ModifiedDateTime,  Class) 
 VALUES
    ('Palacz', 10, 'Antoni Wojciech', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10B'),
    ('Chae', 10, 'Dain', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10B'),
    ('Maj', 10, 'Damian', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10B'),
    ('Anvarov', 10, 'Dinmukhammad', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10B'),
    ('Beliankou', 10, 'Hleb', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10B'),
    ('Ojeda', 10, 'Isabella Ivelisse', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10B'),
    ('Karpilovich', 10, 'Ivanna', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10B'),
    ('Hojakuliyev', 10, 'Kerim', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10B'),
    ('Kopiczko', 10, 'Liliana', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10B'),
    ('Lutek', 10, 'Maja Maria', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10B'),
    ('De Borba', 10, 'Murilo Magnus', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10B'),
    ('Kim', 10, 'Namwoo', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10B'),
    ('Eldem', 10, 'Nesibe', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10B'),
    ('Saini', 10, 'Nimran Kaur', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10B'),
    ('Vempalli', 10, 'Pranav Reddy', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10B'),
    ('Abdyjapbarova', 10, 'Selma', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10B'),
    ('Zhou', 10, 'Tingru', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10B'),
    ('Chang', 10, 'Yu-Hsuan', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10B'),
    ('Noemi', 10, 'Ziontecka Oliwia', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10B');


 INSERT OR REPLACE INTO Students (LastName, Year, FirstName, StudentNumber, CreatedBy, CreatedDateTime, ModifiedBy, ModifiedDateTime,  Class) 
 VALUES
    ('Izhaki', 10, 'Amir', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C'),
    ('Guja', 10, 'Andrew Feliks', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C'),
    ('Giralt', 10, 'Barbara Dias', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C'),
    ('Fletcher', 10, 'Casper Henry', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C'),
    ('Furs', 10, 'Egor', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C'),
    ('Dogan', 10, 'Hatice Rabia', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C'),
    ('Arslan', 10, 'Inci', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C'),
    ('Kucharska', 10, 'Julia', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C'),
    ('Angelini', 10, 'Kevin', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C'),
    ('Michalski', 10, 'Maciej Antoni', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C'),
    ('İbrahimova', 10, 'Merish Esra', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C'),
    ('Lymar', 10, 'Mykhailo', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C'),
    ('Keech', 10, 'Mykyta Patrik', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C'),
    ('Bahadir', 10, 'Omer', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C'),
    ('Kitsaki', 10, 'Pandora', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C'),
    ('Małecka', 10, 'Pola', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C'),
    ('Gothwal', 10, 'Shaurya', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C'),
    ('Sasisekar', 10, 'Shrijan', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C'),
    ('Isler', 10, 'Zak Daniel', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C'),
    ('Ertas', 10, 'Zumra Saadet', printf('%07d', ABS(RANDOM()) % 1000000),  'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'Year10C');


update Students set Year = 12 where Class in ('IB_1A', 'IB_1B', 'AS_1A', 'AS_LevelA', 'As_LevelB');


INSERT INTO Students (LastName, Year, FirstName, StudentNumber, CreatedBy, CreatedDateTime, ModifiedBy, ModifiedDateTime, Class) 
VALUES
    ('Tanrikulu', 13, 'Ezra', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2A'),
    ('Janusz Jaguścil', 13, 'Franciszek', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2A'),
    ('Ge', 13, 'Jiaqi', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2A'),
    ('Jaroszek', 13, 'Kacper', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2A'),
    ('Matulevičius', 13, 'Karolis', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2A'),
    ('Bangar', 13, 'Khushi', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2A'),
    ('Wronka', 13, 'Maria Aleksandra', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2A'),
    ('Van Den Berg', 13, 'Matthias', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2A'),
    ('Lee', 13, 'Minuk', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2A'),
    ('Szul', 13, 'Olga Nina', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2A'),
    ('Chyliński', 13, 'Rafał Michał', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2A'),
    ('Bangar', 13, 'Vanshika', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2A'),
    ('Cakir', 13, 'Zeynep Asude', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2A'),
    ('Deluga', 13, 'Zofia', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2A'),

    ('Ranjane', 13, 'Anvi Amit', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2B'),
    ('Cakar', 13, 'Cebrail Sad', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2B'),
    ('Dyba', 13, 'Emma Krystyna', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2B'),
    ('Regulski', 13, 'Igor Rafał', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2B'),
    ('Czerwonka', 13, 'Maja', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2B'),
    ('Przybysz', 13, 'Margo Angelika', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2B'),
    ('Kruse Thorn', 13, 'Mathilda Maria', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2B'),
    ('Dąbrowska', 13, 'Melania', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2B'),
    ('Fylypczuk', 13, 'Melania', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2B'),
    ('De Leon Gue', 13, 'Niven Lioelle', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2B'),
    ('Allahverdiyev', 13, 'Omar', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2B'),
    ('Nyamona', 13, 'Shumirai Janette', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2B'),
    ('Pham', 13, 'Thuy My', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2B'),
    ('Liu', 13, 'Yifan', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'IB_2B'),

    ('Czutro', 13, 'Aleksander Jakub', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'A_Level'),
    ('Taylor', 13, 'Amelia', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'A_Level'),
    ('Olszewska', 13, 'Anna Zofia', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'A_Level'),
    ('Nguyen', 13, 'Chi Hieu', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'A_Level'),
    ('Ochman', 13, 'Grace Su-Lin', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'A_Level'),
    ('Pundir', 13, 'Harshvardhan', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'A_Level'),
    ('Le Ba', 13, 'Hoang Anh', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'A_Level'),
    ('Cieplińska', 13, 'Julia Anna', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'A_Level'),
    ('Ersoy', 13, 'Leyla', printf('%07d', ABS(RANDOM()) % 1000000), 'AdminS', CURRENT_TIMESTAMP, 'AdminS', CURRENT_TIMESTAMP, 'A_Level');


-- update Students
-- set StudentNumber = printf('%07d', ABS(RANDOM()) % 1000000)
-- WHERE ROWID NOT IN (
--     SELECT MIN(ROWID) 
--     FROM Students
--     GROUP BY StudentNumber
-- )
-- and StudentNumber is not null;