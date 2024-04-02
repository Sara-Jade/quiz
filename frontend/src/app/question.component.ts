import { Component } from "@angular/core";
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule} from '@angular/material/card';

@Component({
    selector: 'question',
    standalone: true,
    imports: [FormsModule, MatCardModule, MatFormFieldModule, MatInputModule],
    templateUrl: './question.component.html',
})

export class QuestionComponent { 
    question: string = '';
    post(question: string): void { 
        console.log(question);
    }
}