export class Triple {
  // Using the 'static' keyword creates a method which is associated
  // with a class, but not with an instance of the class.

  /**
   * Triple the number.
   * @param {Number} n A number to triple.
   * @returns {Number} The tripled number.
   */
  static triple(n) {
    return n * 3;
  }
}
