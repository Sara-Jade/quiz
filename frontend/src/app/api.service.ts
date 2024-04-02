import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ApiService {
    constructor(private http: HttpClient) {
        this.http = http;
    }

    postQuestion(question: any) {
        return this.http.post('http://localhost:5167/api/Questions', question)
            .subscribe(response => { console.log(response); });
    }
}