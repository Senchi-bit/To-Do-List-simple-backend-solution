# ToDoList
<h3>This is my backend application for minimal To-Do list</h3>
You can run and test this app, but you should to do it: 
```
docker build -t todolist .
docker run -i -t -d -p 5065:5065 --name to_do_list2 -e ASPNETCORE_HTTP_PORTS=5065 todolist
```

It`s not a final version