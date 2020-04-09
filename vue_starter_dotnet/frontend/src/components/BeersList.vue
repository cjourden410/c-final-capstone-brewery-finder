<template>
    <table>
        <thead>
            <tr>
                <td>Name</td>
                <td>Type</td>
                <td>ABV</td>
            </tr>
        </thead>
        <tbody>
            <tr v-for="beer in beers" :key="beer.id">
                <td>
                    <router-link :to="{name: 'beerInfo', params:{id:beer.id}}">{{beer.name}}</router-link>
                </td>
                <td>{{beer.beerType}}</td>
                <td>{{beer.abv}}</td>
            </tr>
        </tbody>
    </table>
</template>
<script>
export default {
  name: "beer-list",
  props: {
    beers: Array
  },
  data() {
    return {};
  },
  methods: {},
  computed: {}
};
</script>