import { ApiService } from "./api.service";
import { Component, OnDestroy, OnInit } from "@angular/core";
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Subscription } from "rxjs";
import { StringifyOptions } from "querystring";
import { Question } from "./question";

@Component({
    selector: 'question',
    standalone: true,
    imports: [FormsModule, HttpClientModule, MatCardModule, MatFormFieldModule, MatInputModule],
    templateUrl: './question.component.html',
    providers: [ApiService]
})

export class QuestionComponent implements OnInit, OnDestroy{ 
    question: Question = { id: 0, text: '', correctAnswer: '', wrongAnswers: [] };

    // selectedQuestion: Question = { id: 0, text: '', correctAnswer: '', wrongAnswers: [] };
    private subscription: Subscription = new Subscription();
    
    constructor(private api: ApiService) { 
        // this.subscription = this.api.questionSelected$.subscribe(question => {
        //     this.selectedQuestion = question;
        //     this.question = question;
        // });
        // this.subscription = this.api.selectedQuestion$.subscribe(question => {
        //     // this.selectedQuestion = question;
        //     this.question = question;
        // });
        // this.subscription.add(
        //     this.api.selectedQuestion$.subscribe(question => {
        //       // Do something when the selected option changes
        //       console.log(`Selected question: ${question.text}`);
        //       // You can call the API here to get the question based on the selected option
        //       // this.api.getQuestion(option).subscribe(question => this.question = question);
        //       this.question = question
        //     })
        // );
    }

    /**
     * This component does not get called when the QuestionSet component has a question selected!
     * Need to try this project all over again such that it has an app.module.ts file.
     */
    ngOnInit(): void {
        this.api.selectedQuestion1.subscribe(question => {
            // Do something when the selected option changes
            console.log(`In QuestionComponent ngOnInit()`);
            console.log(`Selected question: ${question.text}`);
            // You can call the API here to get the question based on the selected option
            // this.api.getQuestion(option).subscribe(question => this.question = question);
            this.question = question
        })
    }

    // this.subscription = this.api.questionSelected$.subscribe(question => {
    //     this.selectedQuestion = question;
    //     this.question = question;
    // });

    // ngOnInit() { 
    //     this.api.questionSelected.subscribe(question => {
    //         console.log(`question: ${question}`);
    //         this.question = question;
        // this.subscription = this.api.questionSelected$.subscribe(question => {
        //     this.selectedQuestion = question;
        //     this.question = question;
        //  });

    //     console.log('QuestionComponent initialized');
        // this.subscription.add(this.api.selectQuestion$.subscribe(question => {
        //     this.selectedQuestion = question;
        //     this.question = question;
        // }));
    // }

    ngOnDestroy(): void {
        this.subscription.unsubscribe();
    }

    post(question: any): void { 
        this.api.postQuestion(question);
        // console.log('Question: ' + question.Text);
    }
}