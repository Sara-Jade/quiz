import { Component } from "@angular/core";
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
    selector: 'question',
    standalone: true,
    imports: [MatFormFieldModule, MatInputModule],
    templateUrl: './question.component.html',
})

export class QuestionComponent { }