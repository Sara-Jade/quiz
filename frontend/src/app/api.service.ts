import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Subject } from 'rxjs';
import { Question } from './question';

@Injectable(
   // { providedIn: 'root' }
)
export class ApiService {
    // private selectedQuestion = new Subject<any>();
    private selectedQuestion = new BehaviorSubject<Question>({ id: 0, text: 'default', correctAnswer: '', wrongAnswers: [] });
    // questionSelected$ = this.selectedQuestion.asObservable();
    // private selectedQuestion = new Subject<Question>();
    // private selectedQuestion = new Subject<any>();
    // selectedQuestion = this.selectedQuestion.asObservable();
    selectedQuestion1 = this.selectedQuestion.asObservable();

    constructor(private http: HttpClient) {
        this.http = http;
    }

    /*async*/ getQuestionSet() {
        return /*await*/ this.http.get('http://localhost:5167/api/Questions');
    }

    postQuestion(question: Question) {
        this.http.post('http://localhost:5167/api/Questions', question)
            .subscribe(response => { console.log(response); });
    }

    selectQuestion(question: Question) {
        console.log(`question: ${question.text}`);
        this.selectedQuestion.next(question);
    }
}