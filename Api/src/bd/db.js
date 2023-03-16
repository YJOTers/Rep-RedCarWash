'use strict'
const mysql = require('mysql'), 
      data = require('./credencialesBD.json'),
      dataConexion = {
        host: data.mysql.host,
        port: data.mysql.port,
        user: data.mysql.user,
        password: data.mysql.password,
        database: data.mysql.database
      }

const pool = mysql.createPool(dataConexion)

pool.getConnection((err, connection) => {
    if (err) {
      if (err.code === 'PROTOCOL_CONNECTION_LOST') {
        console.error('Database connection was closed.')
      }
      if (err.code === 'ER_CON_COUNT_ERROR') {
        console.error('Database has too many connections.')
      }
      if (err.code === 'ECONNREFUSED') {
        console.error('Database connection was refused.')
      }
    }

    
if (connection) connection.release()

return
})

module.exports = pool;