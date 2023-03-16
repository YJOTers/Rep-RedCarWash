'use strict'
const util = require('util');
const connection = require('../bd/db');
const query = util.promisify(connection.query).bind(connection);

//Seleccionar tipo de pago
const seleccionar_tipoDePago = async function(req, res){
    const ide = req.params.ide;
    const sql = `SELECT * FROM tipo_de_pago WHERE id_uc_tdp = ${connection.escape(ide)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Actualizar tipo de pago
const actualizar_tipoDePago = async function(req, res){
    const id = req.params.id;
    const sql = `UPDATE tipo_de_pago SET ${connection.escape(req.body)} WHERE id_tdp = ${connection.escape(id)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Insertar tipo de pago
const insertar_tipoDePago = async function(req, res){
    const sql = `INSERT INTO tipo_de_pago SET ${connection.escape(req.body)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Eliminar tipo de pago
const eliminar_tipoDePago = async function(req, res){
    const id = req.params.id; 
    const sql = `DELETE FROM tipo_de_pago WHERE id_tdp = ${connection.escape(id)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}

module.exports = {
    seleccionar_tipoDePago,
    actualizar_tipoDePago,
    insertar_tipoDePago,
    eliminar_tipoDePago
};