This web-app helps me to cotrol my grammar learing. It looks like simple web page with a one table where i can see what tasks i should to do today. When i pass them then i mark them as done and they are hided today. 
Also i can add them through simple web-form where i enter the name and URL of the task. When i pass the task then counter of completions increase on 1. Every night these tasks mark as undone and i can pass them again. 

If u'd like to see it u can go to root of repo and use 'docker compose up' comand. 

Tech stack: .net7/c#, sqlite - database (i've used dapper as orm), front-end - react (actually, chat-gpt 3.5 have almost writen all the fron-end code and styles), hangfire library for tasks scheduling.
