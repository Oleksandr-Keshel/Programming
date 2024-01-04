SELECT name, topic, title
FROM [Authors&Articles]
WHERE topic = 'Health'
AND (name LIKE 'S%' OR name LIKE 'T%')
AND title IN ('Apple','Orange', 'Sleep');