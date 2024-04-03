import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ApiService {
    constructor(private http: HttpClient) {
        this.http = http;
    }

    getQuestionSet() {
        return this.http.get('http://localhost:5167/api/Questions');
    }

    postQuestion(question: any) {
        this.http.post('http://localhost:5167/api/Questions', question)
            .subscribe(response => { console.log(response); });
    }
}