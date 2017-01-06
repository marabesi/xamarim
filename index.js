var express = require('express'),
    fs = require('fs'),
    bodyParser = require('body-parser'),
    methodOverride = require('method-override'),
    morgan = require('morgan'),
    restful = require('node-restful'),
    mongoose = restful.mongoose;
var app = express();

if (fs.existsSync('.env')) {
    require('dotenv').config();
}

app.use(morgan('dev'));
app.use(bodyParser.urlencoded({'extended':'true'}));
app.use(bodyParser.json());
app.use(bodyParser.json({type:'application/vnd.api+json'}));
app.use(methodOverride());

var user = process.env.DB_USER,
    password = process.env.DB_PASSWORD,
    host = process.env.DB_HOST,
    port = process.env.PORT || 8000,
    database = process.env.DB_DATABASE;

if (user == "" && password == "") {
    mongoose.connect("mongodb://" + host + "/" + database);
} else {
    mongoose.connect("mongodb://" + user + ":" + password + "@" + host);
}


function verifyToken(req, res, next) {
    var token = req.query.token;

    if (!token) {
        throw new Error('fail to veirfy token');
    }

    if (token != '123456') {
        throw new Error('Invalid token');
    }

    next();
}

var Users = app.users = restful.model('users', mongoose.Schema({
    name: String,
    password: String,
    email: String,
  }))
  .methods(['get', 'post', 'put', 'delete'])
  .before('get', verifyToken)
  .before('post', verifyToken)
  .before('put', verifyToken)
  .before('delete', verifyToken);

Users.register(app, '/users');

var Sensors = app.sensors = restful.model('sensors', mongoose.Schema({
    name: String,
    description: String,
    type_id: Intl,
    state: Boolean,
    port: String
}))
.methods(['get', 'post', 'put', 'delete'])
.before('get', verifyToken)
.before('post', verifyToken)
.before('put', verifyToken)
.before('delete', verifyToken);

Sensors.register(app, '/sensors');

app.listen(port);

