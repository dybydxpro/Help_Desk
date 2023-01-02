import axios from "axios";

export default axios.create({
    baseURL: "https://localhost:44348/api",
    headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
    }
})