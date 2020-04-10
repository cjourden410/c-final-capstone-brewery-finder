<template>
<div>
    <h1>Your Brewery Ratings and Reviews</h1>
  <table>
      <thead>
          <tr>
              <td>Beer Name</td>
              <td>Beer Rating</td>
              <td>Review</td>
          </tr>
      </thead>
      <tbody>
          <tr v-for="rating in ratings" :key="rating.id">
              <td>{{rating.beerName}}</td>
              <td>{{rating.rating}}</td>
              <td>{{rating.review}}</td>
          </tr>
      </tbody>
  </table>
  </div>
</template>

<script>
export default {
name: "rating-list",
props:{
    ratings: Array
},
data(){
    return{};
},
methods: {},
computed: {}
};
</script>

<style>

</style>