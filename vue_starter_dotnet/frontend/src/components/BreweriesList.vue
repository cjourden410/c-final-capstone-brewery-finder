<template>
    <table>
        <thead>
            <tr>
                <td>Id</td>
                <td>Name</td>
                <td>Brewer</td>
            </tr>
        </thead>
        <tbody>
            <tr v-for="brewery in breweries" :key="brewery.id">
                <td>{{brewery.id}}</td>
                <td>{{brewery.name}}</td>
                <td>{{brewery.brewer}}</td>
            </tr>
        </tbody>
    </table>
</template>
<script>
export default {
  name: "brewery-list",
  props: {
    breweries: Array
  },
  data() {
    return {};
  },
  methods: {},
  computed: {}
};
</script>