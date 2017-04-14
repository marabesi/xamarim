var express = require('express'),
    fs = require('fs'),
    bodyParser = require('body-parser'),
    methodOverride = require('method-override'),
    morgan = require('morgan'),
    restful = require('node-restful'),
    mongoose = restful.mongoose,
    ObjectId = require('mongodb').ObjectId; ;
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

var Users = app.users = restful.model('users', mongoose.Schema({
    name: String,
    password: String,
    email: String,
  }))
  .methods(['get', 'post', 'put', 'delete'])
  .before('get', verifyToken)
  .before('put', verifyToken)
  .before('delete', verifyToken);

Users.register(app, '/users');

var Sensors = app.sensors = restful.model('sensors', mongoose.Schema({
    name: String,
    description: String,
    type_id: Intl,
    state: Boolean,
    port: String,
    url: String,
    pin: Intl,
    in_out: Intl
}))
.methods(['get', 'post', 'put', 'delete'])
.before('get', verifyToken)
.before('post', verifyToken)
.before('put', verifyToken)
.before('delete', verifyToken);

Sensors.register(app, '/sensors');

function verifyToken(req, res, next) {
    var token = req.query.token;

    if (!ObjectId.isValid(token)) {
        throw new Error('Type of token sent is invalid');
    }

    var id = new ObjectId(token);
    
    Users.findById(id, function(error, userFound) {
        if (error) {
            throw new Error('Something went wrong, try again later');;
        }
        
        if (!userFound) {
            throw new Error('fail to verify token');
        }

        if (token != userFound._id) {
            throw new Error('Invalid token');
        }
    });

    next();
}

app.post('/login', function(req, res) {
    var email = req.body.email;
    var password = req.body.password;

    if (!email || !password) {
        throw "Email and password is required";
    }

    Users.findOne({
        email: email,
        password: password
    }, function(error, user) {
        if (error) {
            res.send(error.message);
            return handleError(error);
        }

        if (!user) {
            throw "Could not find any token";
        }

        res.contentType('application/json'); 
        res.send(user);
    });
});

app.listen(port);

