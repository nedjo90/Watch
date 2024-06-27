import {createTheme} from '@mui/material';

export const theme = createTheme({
                              components: {
                                  MuiTextField: {
                                      styleOverrides: {
                                          root: {
                                              '& .MuiInputBase-input': {
                                                  color: 'black',
                                                  borderRadius: '20px'

                                              },
                                              '& .MuiOutlinedInput-root': {
                                                  '& fieldset': {
                                                      borderColor: 'black' // Border color
                                                  },
                                                  '&:hover fieldset': {
                                                      borderColor: 'black' // Border color on hover
                                                  },
                                                  '&.Mui-focused fieldset': {
                                                      borderColor: 'black' // Border color when focused
                                                  }
                                              },
                                              '& .MuiInputBase-root': {
                                                  backgroundColor: 'white', // Background color
                                                  borderRadius: '20px',
                                                  width: '20em',
                                                  height: '3em'
                                              }
                                          }
                                      }
                                  }
                              }
                          });