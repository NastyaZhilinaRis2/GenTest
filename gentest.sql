-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Июн 09 2023 г., 08:34
-- Версия сервера: 10.4.27-MariaDB
-- Версия PHP: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `gentest`
--

-- --------------------------------------------------------

--
-- Структура таблицы `answers`
--

CREATE TABLE `answers` (
  `ID_answer` int(6) NOT NULL,
  `ID_question` int(6) NOT NULL,
  `Text_answer` varchar(200) NOT NULL,
  `Correctly` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Дамп данных таблицы `answers`
--

INSERT INTO `answers` (`ID_answer`, `ID_question`, `Text_answer`, `Correctly`) VALUES
(161, 91, 'Двоичная', 0),
(162, 91, 'Десятичная', 0),
(163, 91, 'Шестидесятиричная', 1),
(164, 91, 'Шестиричная', 0),
(165, 92, 'СС - упорядоченная форма записи числа', 0),
(166, 92, 'Символический метод записи чисел, представление чисел с помощью письменных знаков', 1),
(167, 92, 'Двоичная система, в которой работает компьютер', 0),
(168, 93, '110101010‬101001010010101001010101', 1),
(169, 94, '1', 1),
(170, 94, '0', 1),
(171, 94, 'А', 0),
(172, 94, '10', 0),
(173, 95, 'D', 0),
(174, 95, 'E', 0),
(175, 95, 'G', 1),
(176, 95, 'H', 1),
(177, 95, 'A', 0),
(178, 95, '0', 0),
(179, 96, 'двоичной', 1),
(180, 96, 'двоичная', 1),
(181, 97, 'верно', 1),
(182, 97, 'не верно', 0),
(183, 97, 'не верно', 0),
(184, 97, 'не верно', 0),
(185, 98, 'верно', 1),
(186, 98, 'верно', 1),
(187, 98, 'не верно', 0),
(188, 99, 'верно', 1),
(189, 100, 'верно', 1),
(190, 100, 'не верно', 0),
(191, 100, 'не верно', 0),
(192, 100, 'не верно', 0),
(193, 101, 'не верно', 0),
(194, 101, 'верно', 1),
(195, 101, 'не верно', 0),
(196, 101, 'верно', 1),
(197, 102, 'верно', 1),
(198, 102, 'не верно', 0),
(199, 103, 'не верно', 0),
(200, 103, 'верно', 1),
(201, 103, 'верно', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `disciplines`
--

CREATE TABLE `disciplines` (
  `ID_discipline` int(6) NOT NULL,
  `Name_discipline` varchar(200) NOT NULL,
  `ID_teacher` int(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Дамп данных таблицы `disciplines`
--

INSERT INTO `disciplines` (`ID_discipline`, `Name_discipline`, `ID_teacher`) VALUES
(80, 'Экономика', 55),
(81, 'Правоведение', 55),
(82, '1с', 56),
(83, 'ТРПО', 56),
(84, 'Системное программирование', 56),
(85, 'Прикладное программирование', 56),
(86, 'Информатика', 55),
(87, 'ТРПО', 57);

-- --------------------------------------------------------

--
-- Структура таблицы `groups`
--

CREATE TABLE `groups` (
  `ID_group` int(6) NOT NULL,
  `Name_group` varchar(30) NOT NULL,
  `Kurs` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Дамп данных таблицы `groups`
--

INSERT INTO `groups` (`ID_group`, `Name_group`, `Kurs`) VALUES
(1, 'ИСП-1,2 2019 БО', 4),
(2, 'ИСП-3,4 2019 БО', 4),
(3, 'ПСО - 1,2 2023 БО', 1),
(4, 'ПСО - 3,4 2023 БО', 1),
(5, 'ПСО - 1,2 2022 БО', 2),
(6, 'ПСО - 3,4 2022 БО', 2),
(7, 'ИСП - 1,2 2023 БО', 1),
(8, 'ИСП - 3,4 2023 БО', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `open_tests`
--

CREATE TABLE `open_tests` (
  `ID` int(11) NOT NULL,
  `ID_topic` int(6) NOT NULL,
  `ID_discipline` int(6) NOT NULL,
  `ID_teacher` int(6) NOT NULL,
  `ID_student` int(6) NOT NULL,
  `Try` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Дамп данных таблицы `open_tests`
--

INSERT INTO `open_tests` (`ID`, `ID_topic`, `ID_discipline`, `ID_teacher`, `ID_student`, `Try`) VALUES
(8, 59, 80, 55, 11, 8),
(9, 58, 86, 55, 11, 4),
(10, 60, 86, 55, 11, 5);

-- --------------------------------------------------------

--
-- Дублирующая структура для представления `open_tests_students`
-- (См. Ниже фактическое представление)
--
CREATE TABLE `open_tests_students` (
`ID` int(11)
,`ID_topic` int(6)
,`ID_discipline` int(6)
,`ID_teacher` int(6)
,`Name_topic` varchar(200)
,`ID_student` int(6)
,`Try` int(2)
);

-- --------------------------------------------------------

--
-- Структура таблицы `questions`
--

CREATE TABLE `questions` (
  `ID_question` int(6) NOT NULL,
  `ID_topic` int(6) NOT NULL,
  `Text_question` varchar(500) NOT NULL,
  `Type` varchar(25) NOT NULL,
  `Score` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Дамп данных таблицы `questions`
--

INSERT INTO `questions` (`ID_question`, `ID_topic`, `Text_question`, `Type`, `Score`) VALUES
(91, 58, 'Назовите систему счисления времени', 'Один из многих', 1),
(92, 58, 'Что такое система счисления?', 'Один из многих', 1),
(93, 58, 'Переведите 426 из 10-чной СС в 2-ную', 'Развернутый', 3),
(94, 58, 'В двоичной системе счисления присутствуют символы:', 'Многие из многих', 2),
(95, 58, 'Какие символы НЕ присутствуют в шестнадцатиричной СС', 'Многие из многих', 2),
(96, 58, 'ЭВМ выполняет расчеты в .... СС', 'Развернутый', 3),
(97, 59, 'Первый вопрос', 'Один из многих', 1),
(98, 59, 'Второй вопрос', 'Многие из многих', 2),
(99, 59, 'Третий вопрос', 'Развернутый', 3),
(100, 59, 'Четвертый вопрос', 'Один из многих', 1),
(101, 59, 'Пятый вопрос', 'Многие из многих', 2),
(102, 60, 'Первый вопрос', 'Один из многих', 1),
(103, 60, 'Второй вопрос', 'Многие из многих', 2);

-- --------------------------------------------------------

--
-- Структура таблицы `students`
--

CREATE TABLE `students` (
  `ID_student` int(6) NOT NULL,
  `Surname` varchar(40) NOT NULL,
  `Name` varchar(40) NOT NULL,
  `Middle_name` varchar(40) NOT NULL,
  `Year_of_birth` date NOT NULL,
  `ID_group` int(6) DEFAULT NULL,
  `ID_user` int(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Дамп данных таблицы `students`
--

INSERT INTO `students` (`ID_student`, `Surname`, `Name`, `Middle_name`, `Year_of_birth`, `ID_group`, `ID_user`) VALUES
(11, 'Жилина', 'Анастасия', 'Александровна', '2003-08-04', 1, 3),
(12, 'Иванов', 'Иван', 'Иванович', '2003-05-01', NULL, 6),
(13, 'Иващенко', 'Екатерина', 'Андреевна', '2003-01-01', 1, 7);

-- --------------------------------------------------------

--
-- Структура таблицы `teachers`
--

CREATE TABLE `teachers` (
  `ID_teacher` int(6) NOT NULL,
  `Surname` varchar(40) NOT NULL,
  `Name` varchar(40) NOT NULL,
  `Middle_name` varchar(40) NOT NULL,
  `Year_of_birth` date NOT NULL,
  `ID_user` int(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Дамп данных таблицы `teachers`
--

INSERT INTO `teachers` (`ID_teacher`, `Surname`, `Name`, `Middle_name`, `Year_of_birth`, `ID_user`) VALUES
(55, 'Корлякова', 'Екатерина', 'Владимировна', '0000-00-00', 4),
(56, 'Сарычев', 'Алексей', 'Васильевич', '0000-00-00', 5),
(57, 'Жевлаков', 'Аркадий', 'Викторович', '0000-00-00', 8);

-- --------------------------------------------------------

--
-- Структура таблицы `tests`
--

CREATE TABLE `tests` (
  `ID_test` int(6) NOT NULL,
  `ID_topic` int(6) NOT NULL,
  `ID_student` int(6) NOT NULL,
  `Аssessment` int(3) NOT NULL,
  `Date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Дамп данных таблицы `tests`
--

INSERT INTO `tests` (`ID_test`, `ID_topic`, `ID_student`, `Аssessment`, `Date`) VALUES
(93, 58, 11, 19, '2023-06-09'),
(94, 59, 11, 30, '2023-06-09'),
(95, 59, 11, 19, '2023-06-09');

-- --------------------------------------------------------

--
-- Дублирующая структура для представления `tests_students_assessment`
-- (См. Ниже фактическое представление)
--
CREATE TABLE `tests_students_assessment` (
`ID_test` int(6)
,`ID_teacher` int(6)
,`ID_discipline` int(6)
,`ID_group` int(6)
,`ID_student` int(6)
,`Surname` varchar(40)
,`Name` varchar(40)
,`Middle_name` varchar(40)
,`ID_topic` int(6)
,`Name_topic` varchar(200)
,`Аssessment` int(3)
,`Date` date
);

-- --------------------------------------------------------

--
-- Структура таблицы `test_topics`
--

CREATE TABLE `test_topics` (
  `ID_topic` int(6) NOT NULL,
  `ID_discipline` int(6) NOT NULL,
  `Name_topic` varchar(200) NOT NULL,
  `Number_of_questions` int(2) NOT NULL,
  `ID_teacher` int(6) NOT NULL,
  `Kol_balls` int(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Дамп данных таблицы `test_topics`
--

INSERT INTO `test_topics` (`ID_topic`, `ID_discipline`, `Name_topic`, `Number_of_questions`, `ID_teacher`, `Kol_balls`) VALUES
(58, 86, 'Системы счисления', 5, 55, 30),
(59, 80, 'Проверка, тест по экономике', 5, 55, 30),
(60, 86, 'Проверка, тест по информатике', 2, 55, 20);

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `ID_user` int(11) NOT NULL,
  `User` varchar(40) NOT NULL,
  `Login` varchar(40) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `Code_word` varchar(70) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`ID_user`, `User`, `Login`, `Password`, `Code_word`) VALUES
(1, 'системный администратор', '1', 'C4CA4238A0B923820DCC509A6F75849B', ''),
(2, 'администрация', '2', 'c81e728d9d4c2f636f067f89cc14862c', ''),
(3, 'студент', 'Жилина', '6512BD43D9CAA6E02C990B0A82652DCA', '6C49C42DBDF24B29AB371CC1689A11DA'),
(4, 'преподаватель', 'Корлякова', '6512BD43D9CAA6E02C990B0A82652DCA', 'c31e7a86ebc16641a1b2e6ca8e7c83e9'),
(5, 'преподаватель', 'Сарычев', '6512BD43D9CAA6E02C990B0A82652DCA', '165a645f2f861285f710a9c5ccc09614'),
(6, 'студент', 'Иванов', '6512BD43D9CAA6E02C990B0A82652DCA', 'CD1A2693791E24BB09B002275442D9E2'),
(7, 'студент', 'IvA', '6512BD43D9CAA6E02C990B0A82652DCA', '7DAA5AAB6CF2D544DE82D6E57259F9AB'),
(8, 'преподаватель', 'Жевлаков', '6512BD43D9CAA6E02C990B0A82652DCA', 'e3e7a03f18fd5ad6eff6209d8139b38f');

-- --------------------------------------------------------

--
-- Структура для представления `open_tests_students`
--
DROP TABLE IF EXISTS `open_tests_students`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `open_tests_students`  AS SELECT `open_tests`.`ID` AS `ID`, `open_tests`.`ID_topic` AS `ID_topic`, `open_tests`.`ID_discipline` AS `ID_discipline`, `open_tests`.`ID_teacher` AS `ID_teacher`, `test_topics`.`Name_topic` AS `Name_topic`, `open_tests`.`ID_student` AS `ID_student`, `open_tests`.`Try` AS `Try` FROM (`open_tests` join `test_topics` on(`open_tests`.`ID_topic` = `test_topics`.`ID_topic`))  ;

-- --------------------------------------------------------

--
-- Структура для представления `tests_students_assessment`
--
DROP TABLE IF EXISTS `tests_students_assessment`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `tests_students_assessment`  AS SELECT `tests`.`ID_test` AS `ID_test`, `test_topics`.`ID_teacher` AS `ID_teacher`, `test_topics`.`ID_discipline` AS `ID_discipline`, `students`.`ID_group` AS `ID_group`, `tests`.`ID_student` AS `ID_student`, `students`.`Surname` AS `Surname`, `students`.`Name` AS `Name`, `students`.`Middle_name` AS `Middle_name`, `tests`.`ID_topic` AS `ID_topic`, `test_topics`.`Name_topic` AS `Name_topic`, `tests`.`Аssessment` AS `Аssessment`, `tests`.`Date` AS `Date` FROM ((`tests` join `test_topics` on(`tests`.`ID_topic` = `test_topics`.`ID_topic`)) join `students` on(`tests`.`ID_student` = `students`.`ID_student`))  ;

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `answers`
--
ALTER TABLE `answers`
  ADD PRIMARY KEY (`ID_answer`),
  ADD KEY `ID_question` (`ID_question`);

--
-- Индексы таблицы `disciplines`
--
ALTER TABLE `disciplines`
  ADD PRIMARY KEY (`ID_discipline`),
  ADD KEY `ID_teacher` (`ID_teacher`);

--
-- Индексы таблицы `groups`
--
ALTER TABLE `groups`
  ADD PRIMARY KEY (`ID_group`);

--
-- Индексы таблицы `open_tests`
--
ALTER TABLE `open_tests`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_topic` (`ID_topic`),
  ADD KEY `ID_teacher` (`ID_teacher`),
  ADD KEY `ID_student` (`ID_student`),
  ADD KEY `ID_discipline` (`ID_discipline`);

--
-- Индексы таблицы `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`ID_question`),
  ADD KEY `ID_topic` (`ID_topic`);

--
-- Индексы таблицы `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`ID_student`),
  ADD KEY `ID_group` (`ID_group`),
  ADD KEY `ID_user` (`ID_user`);

--
-- Индексы таблицы `teachers`
--
ALTER TABLE `teachers`
  ADD PRIMARY KEY (`ID_teacher`),
  ADD KEY `ID_user` (`ID_user`);

--
-- Индексы таблицы `tests`
--
ALTER TABLE `tests`
  ADD PRIMARY KEY (`ID_test`),
  ADD KEY `ID_discipline` (`ID_topic`),
  ADD KEY `ID_student` (`ID_student`);

--
-- Индексы таблицы `test_topics`
--
ALTER TABLE `test_topics`
  ADD PRIMARY KEY (`ID_topic`),
  ADD UNIQUE KEY `Name_topic` (`Name_topic`),
  ADD KEY `ID_teacher` (`ID_teacher`),
  ADD KEY `ID_discipline` (`ID_discipline`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID_user`),
  ADD UNIQUE KEY `Login` (`Login`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `answers`
--
ALTER TABLE `answers`
  MODIFY `ID_answer` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=202;

--
-- AUTO_INCREMENT для таблицы `disciplines`
--
ALTER TABLE `disciplines`
  MODIFY `ID_discipline` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=88;

--
-- AUTO_INCREMENT для таблицы `groups`
--
ALTER TABLE `groups`
  MODIFY `ID_group` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT для таблицы `open_tests`
--
ALTER TABLE `open_tests`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT для таблицы `questions`
--
ALTER TABLE `questions`
  MODIFY `ID_question` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=104;

--
-- AUTO_INCREMENT для таблицы `students`
--
ALTER TABLE `students`
  MODIFY `ID_student` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT для таблицы `teachers`
--
ALTER TABLE `teachers`
  MODIFY `ID_teacher` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=58;

--
-- AUTO_INCREMENT для таблицы `tests`
--
ALTER TABLE `tests`
  MODIFY `ID_test` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=96;

--
-- AUTO_INCREMENT для таблицы `test_topics`
--
ALTER TABLE `test_topics`
  MODIFY `ID_topic` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;

--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `ID_user` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `answers`
--
ALTER TABLE `answers`
  ADD CONSTRAINT `answers_ibfk_1` FOREIGN KEY (`ID_question`) REFERENCES `questions` (`ID_question`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `disciplines`
--
ALTER TABLE `disciplines`
  ADD CONSTRAINT `disciplines_ibfk_1` FOREIGN KEY (`ID_teacher`) REFERENCES `teachers` (`ID_teacher`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `open_tests`
--
ALTER TABLE `open_tests`
  ADD CONSTRAINT `open_tests_ibfk_1` FOREIGN KEY (`ID_topic`) REFERENCES `test_topics` (`ID_topic`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `open_tests_ibfk_2` FOREIGN KEY (`ID_student`) REFERENCES `students` (`ID_student`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `open_tests_ibfk_3` FOREIGN KEY (`ID_teacher`) REFERENCES `teachers` (`ID_teacher`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `open_tests_ibfk_4` FOREIGN KEY (`ID_discipline`) REFERENCES `disciplines` (`ID_discipline`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `questions`
--
ALTER TABLE `questions`
  ADD CONSTRAINT `questions_ibfk_1` FOREIGN KEY (`ID_topic`) REFERENCES `test_topics` (`ID_topic`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `students`
--
ALTER TABLE `students`
  ADD CONSTRAINT `students_ibfk_1` FOREIGN KEY (`ID_group`) REFERENCES `groups` (`ID_group`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `students_ibfk_2` FOREIGN KEY (`ID_user`) REFERENCES `users` (`ID_user`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `teachers`
--
ALTER TABLE `teachers`
  ADD CONSTRAINT `teachers_ibfk_1` FOREIGN KEY (`ID_user`) REFERENCES `users` (`ID_user`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `tests`
--
ALTER TABLE `tests`
  ADD CONSTRAINT `tests_ibfk_2` FOREIGN KEY (`ID_student`) REFERENCES `students` (`ID_student`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `tests_ibfk_3` FOREIGN KEY (`ID_topic`) REFERENCES `test_topics` (`ID_topic`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `test_topics`
--
ALTER TABLE `test_topics`
  ADD CONSTRAINT `test_topics_ibfk_1` FOREIGN KEY (`ID_teacher`) REFERENCES `teachers` (`ID_teacher`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `test_topics_ibfk_2` FOREIGN KEY (`ID_discipline`) REFERENCES `disciplines` (`ID_discipline`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
