import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { Router, RoutesRecognized } from '@angular/router';
import { AuthService } from './auth.service';

import { HTopMenuItem } from './shared';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit {
  title = 'app';
  menuItems = new Array<HTopMenuItem>();
  activeItem: HTopMenuItem;

  constructor(public authService: AuthService, private router: Router) {
    this.menuItems.push({
      link: '/',
      text: 'Ton Kho'
    });
    this.menuItems.push({
      link: '/chiphi',
      text: 'Chi Phi'
    });
    this.menuItems.push({
      link: '/donhangcomplex',
      text: 'Don Hang'
    });
    this.menuItems.push({
      link: '/chuyenhangcomplex',
      text: 'Chuyen Hang'
    });
    this.menuItems.push({
      link: '/logout',
      text: '<i class="fa fa-sign-out" aria-hidden="true"></i>'
    });

    console.log('app constructor');
  }

  ngAfterViewInit() {
    this.router.events.subscribe(ev => {
      if (ev instanceof RoutesRecognized) {
        console.log(ev);
        if (ev.url === '/logout') {
          this.authService.logout();
        } else {
          const item = this.menuItems.find(p => p.link === ev.url);

          this.activeItem = item || this.menuItems[0];
        }
      }
    });
  }
}
