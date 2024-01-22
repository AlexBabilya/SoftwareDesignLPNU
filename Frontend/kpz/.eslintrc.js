module.exports = {
    env: {
      browser: true,
      es6: true, // Use 'es6' instead of 'es2021'
    },
    extends: ['eslint:recommended', 'plugin:react/recommended'],
    parserOptions: {
      ecmaFeatures: {
        jsx: true,
      },
      ecmaVersion: 2019, // Specify the ECMAScript version directly
      sourceType: 'module',
    },
    plugins: ['react'],
    rules: {
      // Add your specific rules here
      'react/react-in-jsx-scope': 'off', // This rule is unnecessary when using React 17+
      'react/prop-types': 'off', // Disable prop-types as we might use TypeScript for prop type checking
    },
  };
  