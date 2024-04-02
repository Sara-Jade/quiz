import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class ApiService {
    constructor(private http: HttpClient) {
        this.http = http;
    }

    postQuestion(question: string): Observable<any> {
        return this.http.post('/api/question', { question });
    }
}