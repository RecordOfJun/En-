const express=require('express');
const customerRoute=require('./customer');
const app=express();
const port=5000;

app.get('/', function(req, res){
    res.sendFile(__dirname+"/address.html")
});


app.listen(port, ()=>{

})

app.use('/customer',customerRoute);