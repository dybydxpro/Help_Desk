import httpCommon from "./httpCommon";

class Services{
    getData(){
        return httpCommon.get("/Stock");
    }

    getDataById(id:number){
        return httpCommon.get(`/Stock/${id}`);
    }

    postData(data:any){
        return httpCommon.post("/Stock", data);
    }

    putData(data:any){
        return httpCommon.put("/Stock", data);
    }

    deleteData(id:number){
        return httpCommon.delete(`/Stock/${id}`);
    }
}

export default new Services();