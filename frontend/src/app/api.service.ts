import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { response } from 'express';

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