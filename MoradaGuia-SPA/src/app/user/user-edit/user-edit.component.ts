import { Component, OnInit, ViewChild, Output, HostListener, EventEmitter } from '@angular/core';
import { User } from 'src/app/_models/user';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/_services/user.service';
import { AuthService } from 'src/app/_services/auth.service';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {
  @ViewChild('editForm', {static: true}) editForm: NgForm;
  @Output() getUserEdit = new EventEmitter();
  user: User;
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }
  constructor(private route: ActivatedRoute, private alertify: AlertifyService,
              private userService: UserService, public authService: AuthService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.user = data.user;
      console.log(this.user);
    });
  }

  updateUser() {
    this.userService.updateUser(this.user).subscribe(next => {
      this.alertify.success('Atualizado com sucesso');
      this.editForm.reset(this.user);
      window.location.reload();
    }, error => {
      this.alertify.error(error);
    });
  }
}
