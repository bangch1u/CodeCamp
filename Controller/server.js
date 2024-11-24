const express = require('express');
const axios = require('axios');
const path = require('path');

const app = express();
const port = 3000;

// Cấu hình EJS làm view engine
app.set('view engine', 'ejs');
app.set('views', path.join(__dirname, 'views'));

// Route để gọi API từ Web API C#
app.get('/api/data', async (req, res) => {
    try {
        // Gọi đến Web API C# (đảm bảo URL đúng)
        const response = await axios.get('https://localhost:7224/api/sinhvien');
        // Render view và truyền dữ liệu sinh viên vào
        res.render('sinhvien', { sinhviens: response.data });
    } catch (error) {
        console.error('Error fetching data from Web API:', error);
        res.status(500).send('Error fetching data');
    }
});

app.listen(port, () => {
    console.log(`Node.js server is running on http://localhost:${port}`);
});
