import { Injectable } from '@angular/core';
import { User } from '../model/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

constructor() { }

addUser(user: User){
  let users = [];
  if (localStorage.getItem('Users')){
    users = JSON.parse(localStorage.getItem('Users'));
    users = [user, ...users]; //swap the inputs if you want to add the user at the end
  }else{
    users = [user];
  }
  localStorage.setItem('Users', JSON.stringify(users)); //all that is needed to store in browser's local storage
}
}
