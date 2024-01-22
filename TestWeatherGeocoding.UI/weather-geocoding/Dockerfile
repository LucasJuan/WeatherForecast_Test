# Using an official Node.js runtime as the base image
FROM node:14

# Setting the working directory inside the container
WORKDIR /app

# Copy package.json and package-lock.json to working directory
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the application to the container
COPY . .

ARG REACT_APP_PORT

ENV REACT_APP_PORT 3000

# Build the Application
RUN npm run build

# Expose the port the application will run on
EXPOSE 3000

# Command to start the app
CMD ["npm", "start"]
