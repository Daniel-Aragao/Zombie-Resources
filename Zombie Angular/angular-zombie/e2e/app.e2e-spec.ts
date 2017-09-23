import { AngularZombiePage } from './app.po';

describe('angular-zombie App', () => {
  let page: AngularZombiePage;

  beforeEach(() => {
    page = new AngularZombiePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
