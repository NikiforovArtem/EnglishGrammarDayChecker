# pull official base image
FROM node:16.17.1-alpine3.15

# set working directory
WORKDIR /app

# add `/app/node_modules/.bin` to $PATH
ENV PATH /app/node_modules/.bin:$PATH

# install app dependencies
COPY ./FrontEnd/english-grammar-tasks/package.json ./
COPY ./FrontEnd/english-grammar-tasks/package-lock.json ./
RUN npm install

# add app
COPY ./FrontEnd/english-grammar-tasks/ ./

# start app
CMD ["npm", "start"]