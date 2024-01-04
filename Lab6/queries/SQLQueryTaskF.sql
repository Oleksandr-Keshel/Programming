SELECT COUNT(id) AS 'number_of_authors', topic
FROM [Authors&Articles]
GROUP BY topic;