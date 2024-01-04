SELECT id, name, topic, title
FROM [Authors&Articles]
WHERE illustration IS NOT NUll
AND name LIKE 'S%'
AND topic NOT IN ('Health','Entertainment')
AND id BETWEEN 5 AND 15;